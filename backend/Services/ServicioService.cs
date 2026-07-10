using AutoMapper;
using Backend.Common.Exceptions;
using Backend.Common.Validation;
using Backend.DTOs.Servicios;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public sealed class ServicioService(
    IServicioRepository repository,
    IMapper mapper,
    ILogger<ServicioService> logger) : IServicioService
{
    public async Task<IReadOnlyList<ServicioDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Iniciando consulta de servicios");
            var servicios = await repository.GetAllAsync<ServicioDto>(mapper.ConfigurationProvider, cancellationToken);
            logger.LogInformation("Consulta de servicios completada con {Cantidad} registros", servicios.Count);
            return servicios;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar servicios");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar servicios", "No fue posible obtener los servicios.");
        }
    }

    public async Task<ServicioDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "servicio");
            logger.LogInformation("Iniciando consulta del servicio {ServicioId}", id);

            var servicio = await repository.GetByIdAsync<ServicioDto>(id, mapper.ConfigurationProvider, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el servicio {id}.");

            logger.LogInformation("Consulta del servicio {ServicioId} completada", id);
            return servicio;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar servicio");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar servicio", $"No fue posible obtener el servicio {id}.");
        }
    }

    public async Task<ServicioDto> CreateAsync(CreateServicioDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ValidatePrice(dto.PrecioPorHora);
            logger.LogInformation("Iniciando creacion de servicio");

            var servicio = mapper.Map<Servicio>(dto);
            Normalize(servicio, dto.Nombre, dto.Descripcion);
            servicio.FechaCreacion = DateTime.UtcNow;
            servicio.Activo = true;

            await repository.CreateAsync(servicio, cancellationToken);
            logger.LogInformation("Servicio {ServicioId} creado correctamente", servicio.Id);
            return mapper.Map<ServicioDto>(servicio);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "crear servicio");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "crear servicio", "No fue posible crear el servicio.");
        }
    }

    public async Task<ServicioDto> UpdateAsync(
        int id,
        UpdateServicioDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "servicio");
            ValidatePrice(dto.PrecioPorHora);
            logger.LogInformation("Iniciando actualizacion del servicio {ServicioId}", id);

            var servicio = await repository.GetForUpdateAsync(id, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el servicio {id}.");

            mapper.Map(dto, servicio);
            Normalize(servicio, dto.Nombre, dto.Descripcion);
            await repository.UpdateAsync(servicio, cancellationToken);

            logger.LogInformation("Servicio {ServicioId} actualizado correctamente", id);
            return mapper.Map<ServicioDto>(servicio);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "actualizar servicio");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "actualizar servicio", $"No fue posible actualizar el servicio {id}.");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "servicio");
            logger.LogInformation("Iniciando eliminacion logica del servicio {ServicioId}", id);

            if (!await repository.DeleteAsync(id, cancellationToken))
            {
                throw new NotFoundException($"No se encontro el servicio {id}.");
            }

            logger.LogInformation("Servicio {ServicioId} eliminado logicamente", id);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "eliminar servicio");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "eliminar servicio", $"No fue posible eliminar el servicio {id}.");
        }
    }

    private static void ValidatePrice(decimal price)
    {
        if (price < 0)
        {
            throw new BusinessValidationException("El precio por hora del servicio no puede ser negativo.");
        }
    }

    private static void Normalize(Servicio servicio, string nombre, string? descripcion)
    {
        servicio.Nombre = TextNormalizer.Required(nombre);
        servicio.Descripcion = TextNormalizer.Optional(descripcion);
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
