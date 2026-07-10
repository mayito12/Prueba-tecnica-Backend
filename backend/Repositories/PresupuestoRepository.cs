using Backend.Common.Exceptions;
using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public sealed class PresupuestoRepository(
    AppDbContext context,
    ILogger<PresupuestoRepository> logger) : IPresupuestoRepository
{
    public async Task<IReadOnlyList<Presupuesto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando presupuestos con sus detalles");
            return await ReadQuery()
                .OrderBy(presupuesto => presupuesto.Id)
                .ToListAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar presupuestos");
            throw new RepositoryException("No fue posible consultar los presupuestos.", exception);
        }
    }

    public async Task<Presupuesto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando presupuesto {PresupuestoId}", id);
            return await ReadQuery()
                .SingleOrDefaultAsync(presupuesto => presupuesto.Id == id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar presupuesto {PresupuestoId}", id);
            throw new RepositoryException($"No fue posible consultar el presupuesto {id}.", exception);
        }
    }

    public async Task<IReadOnlyList<Presupuesto>> GetByClienteIdAsync(
        int clienteId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando presupuestos del cliente {ClienteId}", clienteId);
            return await ReadQuery()
                .Where(presupuesto => presupuesto.ClienteId == clienteId)
                .OrderBy(presupuesto => presupuesto.Id)
                .ToListAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar presupuestos del cliente {ClienteId}", clienteId);
            throw new RepositoryException($"No fue posible consultar los presupuestos del cliente {clienteId}.", exception);
        }
    }

    public async Task<Presupuesto?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando presupuesto {PresupuestoId} para modificacion", id);
            return await context.Presupuestos
                .SingleOrDefaultAsync(presupuesto => presupuesto.Id == id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar presupuesto {PresupuestoId} para modificacion", id);
            throw new RepositoryException($"No fue posible consultar el presupuesto {id}.", exception);
        }
    }

    public async Task<Presupuesto> CreateAsync(
        Presupuesto presupuesto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation(
                "Persistiendo presupuesto para el cliente {ClienteId} con {Productos} productos y {Servicios} servicios",
                presupuesto.ClienteId,
                presupuesto.PresupuestoProductos.Count,
                presupuesto.PresupuestoServicios.Count);

            await context.Presupuestos.AddAsync(presupuesto, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Presupuesto {PresupuestoId} persistido", presupuesto.Id);
            return presupuesto;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al crear presupuesto para el cliente {ClienteId}", presupuesto.ClienteId);
            throw new RepositoryException("No fue posible crear el presupuesto.", exception);
        }
    }

    public async Task UpdateAsync(Presupuesto presupuesto, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Persistiendo cambios del presupuesto {PresupuestoId}", presupuesto.Id);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al actualizar presupuesto {PresupuestoId}", presupuesto.Id);
            throw new RepositoryException($"No fue posible actualizar el presupuesto {presupuesto.Id}.", exception);
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Eliminando fisicamente el presupuesto {PresupuestoId}", id);
            var presupuesto = await context.Presupuestos
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);

            if (presupuesto is null)
            {
                return false;
            }

            context.Presupuestos.Remove(presupuesto);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al eliminar presupuesto {PresupuestoId}", id);
            throw new RepositoryException($"No fue posible eliminar el presupuesto {id}.", exception);
        }
    }

    private IQueryable<Presupuesto> ReadQuery()
    {
        return context.Presupuestos
            .AsNoTracking()
            .Include(presupuesto => presupuesto.Cliente)
            .Include(presupuesto => presupuesto.PresupuestoProductos)
                .ThenInclude(detalle => detalle.Producto)
            .Include(presupuesto => presupuesto.PresupuestoServicios)
                .ThenInclude(detalle => detalle.Servicio)
            .AsSplitQuery();
    }
}
