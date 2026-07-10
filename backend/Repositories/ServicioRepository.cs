using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Common.Exceptions;
using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public sealed class ServicioRepository(
    AppDbContext context,
    ILogger<ServicioRepository> logger) : IServicioRepository
{
    public async Task<IReadOnlyList<TProjection>> GetAllAsync<TProjection>(
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando servicios activos");
            return await context.Servicios
                .AsNoTracking()
                .Where(servicio => servicio.Activo)
                .OrderBy(servicio => servicio.Id)
                .ProjectTo<TProjection>(mappingConfiguration)
                .ToListAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar servicios activos");
            throw new RepositoryException("No fue posible consultar los servicios.", exception);
        }
    }

    public async Task<TProjection?> GetByIdAsync<TProjection>(
        int id,
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando servicio activo {ServicioId}", id);
            return await context.Servicios
                .AsNoTracking()
                .Where(servicio => servicio.Activo && servicio.Id == id)
                .ProjectTo<TProjection>(mappingConfiguration)
                .SingleOrDefaultAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar servicio {ServicioId}", id);
            throw new RepositoryException($"No fue posible consultar el servicio {id}.", exception);
        }
    }

    public async Task<Servicio?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando servicio {ServicioId} para modificacion", id);
            return await context.Servicios
                .SingleOrDefaultAsync(servicio => servicio.Activo && servicio.Id == id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar servicio {ServicioId} para modificacion", id);
            throw new RepositoryException($"No fue posible consultar el servicio {id}.", exception);
        }
    }

    public async Task<IReadOnlyDictionary<int, Servicio>> GetActiveByIdsAsync(
        IEnumerable<int> ids,
        CancellationToken cancellationToken = default)
    {
        var uniqueIds = ids.Distinct().ToArray();

        try
        {
            logger.LogInformation("Consultando {Cantidad} servicios para presupuesto", uniqueIds.Length);
            return await context.Servicios
                .AsNoTracking()
                .Where(servicio => servicio.Activo && uniqueIds.Contains(servicio.Id))
                .ToDictionaryAsync(servicio => servicio.Id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar servicios para presupuesto");
            throw new RepositoryException("No fue posible consultar los servicios del presupuesto.", exception);
        }
    }

    public async Task<Servicio> CreateAsync(Servicio servicio, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Persistiendo nuevo servicio");
            await context.Servicios.AddAsync(servicio, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Servicio {ServicioId} persistido", servicio.Id);
            return servicio;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al crear servicio");
            throw new RepositoryException("No fue posible crear el servicio.", exception);
        }
    }

    public async Task UpdateAsync(Servicio servicio, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Persistiendo cambios del servicio {ServicioId}", servicio.Id);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al actualizar servicio {ServicioId}", servicio.Id);
            throw new RepositoryException($"No fue posible actualizar el servicio {servicio.Id}.", exception);
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Aplicando soft delete al servicio {ServicioId}", id);
            var servicio = await context.Servicios
                .SingleOrDefaultAsync(item => item.Activo && item.Id == id, cancellationToken);

            if (servicio is null)
            {
                return false;
            }

            servicio.Activo = false;
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al eliminar servicio {ServicioId}", id);
            throw new RepositoryException($"No fue posible eliminar el servicio {id}.", exception);
        }
    }
}
