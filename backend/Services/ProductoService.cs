using AutoMapper;
using Backend.Common.Exceptions;
using Backend.Common.Validation;
using Backend.DTOs.Productos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public sealed class ProductoService(
    IProductoRepository repository,
    IMapper mapper,
    ILogger<ProductoService> logger) : IProductoService
{
    public async Task<IReadOnlyList<ProductoDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Iniciando consulta de productos");
            var productos = await repository.GetAllAsync<ProductoDto>(mapper.ConfigurationProvider, cancellationToken);
            logger.LogInformation("Consulta de productos completada con {Cantidad} registros", productos.Count);
            return productos;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar productos");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar productos", "No fue posible obtener los productos.");
        }
    }

    public async Task<ProductoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "producto");
            logger.LogInformation("Iniciando consulta del producto {ProductoId}", id);

            var producto = await repository.GetByIdAsync<ProductoDto>(id, mapper.ConfigurationProvider, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el producto {id}.");

            logger.LogInformation("Consulta del producto {ProductoId} completada", id);
            return producto;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar producto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar producto", $"No fue posible obtener el producto {id}.");
        }
    }

    public async Task<ProductoDto> CreateAsync(CreateProductoDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ValidateValues(dto.Precio, dto.Stock);
            logger.LogInformation("Iniciando creacion de producto");

            var producto = mapper.Map<Producto>(dto);
            Normalize(producto, dto.Nombre, dto.Descripcion);
            producto.FechaCreacion = DateTime.UtcNow;
            producto.Activo = true;

            await repository.CreateAsync(producto, cancellationToken);
            logger.LogInformation("Producto {ProductoId} creado correctamente", producto.Id);
            return mapper.Map<ProductoDto>(producto);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "crear producto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "crear producto", "No fue posible crear el producto.");
        }
    }

    public async Task<ProductoDto> UpdateAsync(
        int id,
        UpdateProductoDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "producto");
            ValidateValues(dto.Precio, dto.Stock);
            logger.LogInformation("Iniciando actualizacion del producto {ProductoId}", id);

            var producto = await repository.GetForUpdateAsync(id, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el producto {id}.");

            mapper.Map(dto, producto);
            Normalize(producto, dto.Nombre, dto.Descripcion);
            await repository.UpdateAsync(producto, cancellationToken);

            logger.LogInformation("Producto {ProductoId} actualizado correctamente", id);
            return mapper.Map<ProductoDto>(producto);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "actualizar producto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "actualizar producto", $"No fue posible actualizar el producto {id}.");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "producto");
            logger.LogInformation("Iniciando eliminacion logica del producto {ProductoId}", id);

            if (!await repository.DeleteAsync(id, cancellationToken))
            {
                throw new NotFoundException($"No se encontro el producto {id}.");
            }

            logger.LogInformation("Producto {ProductoId} eliminado logicamente", id);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "eliminar producto");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "eliminar producto", $"No fue posible eliminar el producto {id}.");
        }
    }

    private static void ValidateValues(decimal precio, int stock)
    {
        if (precio < 0)
        {
            throw new BusinessValidationException("El precio del producto no puede ser negativo.");
        }

        if (stock < 0)
        {
            throw new BusinessValidationException("El stock del producto no puede ser negativo.");
        }
    }

    private static void Normalize(Producto producto, string nombre, string? descripcion)
    {
        producto.Nombre = TextNormalizer.Required(nombre);
        producto.Descripcion = TextNormalizer.Optional(descripcion);
    }

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
