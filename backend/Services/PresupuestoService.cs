using AutoMapper;
using Backend.Common.Exceptions;
using Backend.Common.Validation;
using Backend.DTOs.Presupuestos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public sealed class PresupuestoService(
    IPresupuestoRepository presupuestoRepository,
    IClienteRepository clienteRepository,
    IProductoRepository productoRepository,
    IServicioRepository servicioRepository,
    IMapper mapper,
    ILogger<PresupuestoService> logger) : IPresupuestoService
{
    public async Task<IReadOnlyList<PresupuestoDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Iniciando consulta de presupuestos");
            var presupuestos = await presupuestoRepository.GetAllAsync(cancellationToken);
            var result = presupuestos.Select(MapPresupuesto).ToList();
            logger.LogInformation("Consulta de presupuestos completada con {Cantidad} registros", result.Count);
            return result;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar presupuestos");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar presupuestos", "No fue posible obtener los presupuestos.");
        }
    }

    public async Task<PresupuestoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "presupuesto");
            logger.LogInformation("Iniciando consulta del presupuesto {PresupuestoId}", id);

            var presupuesto = await presupuestoRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el presupuesto {id}.");

            logger.LogInformation("Consulta del presupuesto {PresupuestoId} completada", id);
            return MapPresupuesto(presupuesto);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar presupuesto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar presupuesto", $"No fue posible obtener el presupuesto {id}.");
        }
    }

    public async Task<PresupuestoDto> CreateAsync(
        CreatePresupuestoDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(dto.ClienteId, "cliente");
            ValidateItems(dto.Items);
            logger.LogInformation(
                "Iniciando creacion de presupuesto para el cliente {ClienteId} con {Cantidad} items",
                dto.ClienteId,
                dto.Items.Count);

            if (!await clienteRepository.ExistsActiveAsync(dto.ClienteId, cancellationToken))
            {
                throw new NotFoundException($"No se encontro el cliente activo {dto.ClienteId}.");
            }

            var productItems = dto.Items.Where(IsProduct).ToList();
            var serviceItems = dto.Items.Where(IsService).ToList();

            var products = await productoRepository.GetActiveByIdsAsync(
                productItems.Select(item => item.ItemId),
                cancellationToken);
            var services = await servicioRepository.GetActiveByIdsAsync(
                serviceItems.Select(item => item.ItemId),
                cancellationToken);

            ValidateReferencedItems(productItems, products.Keys, "productos");
            ValidateReferencedItems(serviceItems, services.Keys, "servicios");

            var presupuesto = new Presupuesto
            {
                ClienteId = dto.ClienteId,
                FechaCreacion = DateTime.UtcNow,
                Estado = EstadoPresupuesto.Pendiente
            };

            foreach (var item in productItems)
            {
                var product = products[item.ItemId];
                var subtotal = CalculateSubtotal(product.Precio, item.Cantidad);
                presupuesto.PresupuestoProductos.Add(new PresupuestoProducto
                {
                    ProductoId = product.Id,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = product.Precio,
                    Subtotal = subtotal
                });
            }

            foreach (var item in serviceItems)
            {
                var service = services[item.ItemId];
                var subtotal = CalculateSubtotal(service.PrecioPorHora, item.Cantidad);
                presupuesto.PresupuestoServicios.Add(new PresupuestoServicio
                {
                    ServicioId = service.Id,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = service.PrecioPorHora,
                    Subtotal = subtotal
                });
            }

            presupuesto.Total = presupuesto.PresupuestoProductos.Sum(item => item.Subtotal)
                + presupuesto.PresupuestoServicios.Sum(item => item.Subtotal);

            await presupuestoRepository.CreateAsync(presupuesto, cancellationToken);

            var created = await presupuestoRepository.GetByIdAsync(presupuesto.Id, cancellationToken)
                ?? throw new ServiceException(
                    "El presupuesto fue creado, pero no pudo recuperarse.",
                    new InvalidOperationException("The created budget could not be loaded."));

            logger.LogInformation(
                "Presupuesto {PresupuestoId} creado con total {Total}",
                created.Id,
                created.Total);
            return MapPresupuesto(created);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "crear presupuesto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "crear presupuesto", "No fue posible crear el presupuesto.");
        }
    }

    public async Task<PresupuestoDto> UpdateEstadoAsync(
        int id,
        UpdateEstadoDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "presupuesto");
            if (!Enum.TryParse<EstadoPresupuesto>(dto.Estado, true, out var estado)
                || !Enum.IsDefined(estado))
            {
                throw new BusinessValidationException(
                    "El estado debe ser Pendiente, Aprobado o Rechazado.");
            }

            logger.LogInformation(
                "Iniciando actualizacion del presupuesto {PresupuestoId} al estado {Estado}",
                id,
                estado);

            var presupuesto = await presupuestoRepository.GetForUpdateAsync(id, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el presupuesto {id}.");

            presupuesto.Estado = estado;
            await presupuestoRepository.UpdateAsync(presupuesto, cancellationToken);

            var updated = await presupuestoRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new ServiceException(
                    "El presupuesto fue actualizado, pero no pudo recuperarse.",
                    new InvalidOperationException("The updated budget could not be loaded."));

            logger.LogInformation("Estado del presupuesto {PresupuestoId} actualizado a {Estado}", id, estado);
            return MapPresupuesto(updated);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "actualizar estado de presupuesto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(
                exception,
                "actualizar estado de presupuesto",
                $"No fue posible actualizar el presupuesto {id}.");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "presupuesto");
            logger.LogInformation("Iniciando eliminacion del presupuesto {PresupuestoId}", id);

            if (!await presupuestoRepository.DeleteAsync(id, cancellationToken))
            {
                throw new NotFoundException($"No se encontro el presupuesto {id}.");
            }

            logger.LogInformation("Presupuesto {PresupuestoId} eliminado", id);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "eliminar presupuesto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "eliminar presupuesto", $"No fue posible eliminar el presupuesto {id}.");
        }
    }

    public async Task<IReadOnlyList<PresupuestoDto>> GetByClienteIdAsync(
        int clienteId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(clienteId, "cliente");
            logger.LogInformation("Iniciando consulta de presupuestos del cliente {ClienteId}", clienteId);

            var presupuestos = await presupuestoRepository.GetByClienteIdAsync(clienteId, cancellationToken);
            var result = presupuestos.Select(MapPresupuesto).ToList();
            logger.LogInformation(
                "Consulta de presupuestos del cliente {ClienteId} completada con {Cantidad} registros",
                clienteId,
                result.Count);
            return result;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar presupuestos por cliente");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(
                exception,
                "consultar presupuestos por cliente",
                $"No fue posible obtener los presupuestos del cliente {clienteId}.");
        }
    }

    private PresupuestoDto MapPresupuesto(Presupuesto presupuesto)
    {
        var dto = mapper.Map<PresupuestoDto>(presupuesto);
        var productItems = mapper.Map<IEnumerable<PresupuestoItemDto>>(presupuesto.PresupuestoProductos);
        var serviceItems = mapper.Map<IEnumerable<PresupuestoItemDto>>(presupuesto.PresupuestoServicios);

        dto.Items = productItems
            .Concat(serviceItems)
            .OrderBy(item => item.Tipo)
            .ThenBy(item => item.Id)
            .ToList();
        return dto;
    }

    private static void ValidateItems(IReadOnlyCollection<CreatePresupuestoItemDto>? items)
    {
        if (items is null || items.Count == 0)
        {
            throw new BusinessValidationException("El presupuesto debe contener al menos un item.");
        }

        foreach (var item in items)
        {
            if (!IsProduct(item) && !IsService(item))
            {
                throw new BusinessValidationException("Cada item debe ser de tipo Producto o Servicio.");
            }

            Guard.PositiveId(item.ItemId, "item");
            if (item.Cantidad <= 0)
            {
                throw new BusinessValidationException("La cantidad de cada item debe ser mayor que cero.");
            }
        }
    }

    private static void ValidateReferencedItems(
        IEnumerable<CreatePresupuestoItemDto> items,
        IEnumerable<int> availableIds,
        string resourceName)
    {
        var available = availableIds.ToHashSet();
        var missing = items
            .Select(item => item.ItemId)
            .Distinct()
            .Where(id => !available.Contains(id))
            .OrderBy(id => id)
            .ToArray();

        if (missing.Length > 0)
        {
            throw new NotFoundException(
                $"No se encontraron {resourceName} activos con los identificadores: {string.Join(", ", missing)}.");
        }
    }

    private static decimal CalculateSubtotal(decimal price, int quantity)
    {
        try
        {
            return checked(price * quantity);
        }
        catch (OverflowException)
        {
            throw new BusinessValidationException("El subtotal excede el valor permitido.");
        }
    }

    private static bool IsProduct(CreatePresupuestoItemDto item) =>
        string.Equals(item.Tipo, "Producto", StringComparison.OrdinalIgnoreCase);

    private static bool IsService(CreatePresupuestoItemDto item) =>
        string.Equals(item.Tipo, "Servicio", StringComparison.OrdinalIgnoreCase);

    private static bool IsBusinessException(Exception exception) =>
        exception is NotFoundException or BusinessValidationException or ConflictException;

    private void LogBusinessException(Exception exception, string operation)
    {
        logger.LogWarning("No se pudo {Operacion}: {Message}", operation, exception.Message);
    }

    private ServiceException WrapException(Exception exception, string operation, string clientMessage)
    {
        if (exception is RepositoryException)
        {
            logger.LogWarning("Fallo de repositorio al {Operacion}: {Message}", operation, exception.Message);
        }
        else
        {
            logger.LogError(exception, "Error inesperado al {Operacion}", operation);
        }

        return new ServiceException(clientMessage, exception);
    }
}
