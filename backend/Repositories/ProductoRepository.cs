using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Common.Exceptions;
using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public sealed class ProductoRepository(
    AppDbContext context,
    ILogger<ProductoRepository> logger) : IProductoRepository
{
    public async Task<IReadOnlyList<TProjection>> GetAllAsync<TProjection>(
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando productos activos");
            return await context.Productos
                .AsNoTracking()
                .Where(producto => producto.Activo)
                .OrderBy(producto => producto.Id)
                .ProjectTo<TProjection>(mappingConfiguration)
                .ToListAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar productos activos");
            throw new RepositoryException("No fue posible consultar los productos.", exception);
        }
    }

    public async Task<TProjection?> GetByIdAsync<TProjection>(
        int id,
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando producto activo {ProductoId}", id);
            return await context.Productos
                .AsNoTracking()
                .Where(producto => producto.Activo && producto.Id == id)
                .ProjectTo<TProjection>(mappingConfiguration)
                .SingleOrDefaultAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar producto {ProductoId}", id);
            throw new RepositoryException($"No fue posible consultar el producto {id}.", exception);
        }
    }

    public async Task<Producto?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Consultando producto {ProductoId} para modificacion", id);
            return await context.Productos
                .SingleOrDefaultAsync(producto => producto.Activo && producto.Id == id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar producto {ProductoId} para modificacion", id);
            throw new RepositoryException($"No fue posible consultar el producto {id}.", exception);
        }
    }

    public async Task<IReadOnlyDictionary<int, Producto>> GetActiveByIdsAsync(
        IEnumerable<int> ids,
        CancellationToken cancellationToken = default)
    {
        var uniqueIds = ids.Distinct().ToArray();

        try
        {
            logger.LogInformation("Consultando {Cantidad} productos para presupuesto", uniqueIds.Length);
            return await context.Productos
                .AsNoTracking()
                .Where(producto => producto.Activo && uniqueIds.Contains(producto.Id))
                .ToDictionaryAsync(producto => producto.Id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al consultar productos para presupuesto");
            throw new RepositoryException("No fue posible consultar los productos del presupuesto.", exception);
        }
    }

    public async Task<Producto> CreateAsync(Producto producto, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Persistiendo nuevo producto");
            await context.Productos.AddAsync(producto, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Producto {ProductoId} persistido", producto.Id);
            return producto;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al crear producto");
            throw new RepositoryException("No fue posible crear el producto.", exception);
        }
    }

    public async Task UpdateAsync(Producto producto, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Persistiendo cambios del producto {ProductoId}", producto.Id);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al actualizar producto {ProductoId}", producto.Id);
            throw new RepositoryException($"No fue posible actualizar el producto {producto.Id}.", exception);
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Aplicando soft delete al producto {ProductoId}", id);
            var producto = await context.Productos
                .SingleOrDefaultAsync(item => item.Activo && item.Id == id, cancellationToken);

            if (producto is null)
            {
                return false;
            }

            producto.Activo = false;
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Error de datos al eliminar producto {ProductoId}", id);
            throw new RepositoryException($"No fue posible eliminar el producto {id}.", exception);
        }
    }
}
