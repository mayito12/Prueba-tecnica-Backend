using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Common.Exceptions;
using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public sealed class ClienteRepository(
    AppDbContext context,
    ILogger<ClienteRepository> logger) : IClienteRepository
{
    public async Task<IReadOnlyList<TProjection>> GetAllAsync<TProjection>(
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando clientes activos");
            return await context.Clientes
                .AsNoTracking()
                .Where(cliente => cliente.Activo)
                .OrderBy(cliente => cliente.Id)
                .ProjectTo<TProjection>(mappingConfiguration)
                .ToListAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar clientes activos");
            throw new RepositoryException("No fue posible consultar los clientes.", exception);
        }
    }

    public async Task<TProjection?> GetByIdAsync<TProjection>(
        int id,
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando cliente activo {ClienteId}", id);
            return await context.Clientes
                .AsNoTracking()
                .Where(cliente => cliente.Activo && cliente.Id == id)
                .ProjectTo<TProjection>(mappingConfiguration)
                .SingleOrDefaultAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar cliente {ClienteId}", id);
            throw new RepositoryException($"No fue posible consultar el cliente {id}.", exception);
        }
    }

    public async Task<Cliente?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando cliente {ClienteId} para modificacion", id);
            return await context.Clientes
                .SingleOrDefaultAsync(cliente => cliente.Activo && cliente.Id == id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar cliente {ClienteId} para modificacion", id);
            throw new RepositoryException($"No fue posible consultar el cliente {id}.", exception);
        }
    }

    public async Task<bool> ExistsActiveAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.Clientes
                .AsNoTracking()
                .AnyAsync(cliente => cliente.Activo && cliente.Id == id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al validar cliente {ClienteId}", id);
            throw new RepositoryException($"No fue posible validar el cliente {id}.", exception);
        }
    }

    public async Task<bool> EmailExistsAsync(
        string normalizedEmail,
        int? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.Clientes
                .AsNoTracking()
                .AnyAsync(
                    cliente => cliente.Activo
                        && cliente.Email.ToUpper() == normalizedEmail
                        && (!excludedId.HasValue || cliente.Id != excludedId.Value),
                    cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al validar la unicidad del correo de cliente");
            throw new RepositoryException("No fue posible validar el correo del cliente.", exception);
        }
    }

    public async Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Persistiendo nuevo cliente");
            await context.Clientes.AddAsync(cliente, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Cliente {ClienteId} persistido", cliente.Id);
            return cliente;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al crear cliente");
            throw new RepositoryException("No fue posible crear el cliente.", exception);
        }
    }

    public async Task UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Persistiendo cambios del cliente {ClienteId}", cliente.Id);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al actualizar cliente {ClienteId}", cliente.Id);
            throw new RepositoryException($"No fue posible actualizar el cliente {cliente.Id}.", exception);
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Aplicando soft delete al cliente {ClienteId}", id);
            var cliente = await context.Clientes
                .SingleOrDefaultAsync(item => item.Activo && item.Id == id, cancellationToken);

            if (cliente is null)
            {
                return false;
            }

            cliente.Activo = false;
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al eliminar cliente {ClienteId}", id);
            throw new RepositoryException($"No fue posible eliminar el cliente {id}.", exception);
        }
    }
}
