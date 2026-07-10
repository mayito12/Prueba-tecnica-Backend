using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IProductoRepository
{
    Task<IReadOnlyList<TProjection>> GetAllAsync<TProjection>(
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default);

    Task<TProjection?> GetByIdAsync<TProjection>(
        int id,
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default);

    Task<Producto?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyDictionary<int, Producto>> GetActiveByIdsAsync(
        IEnumerable<int> ids,
        CancellationToken cancellationToken = default);

    Task<Producto> CreateAsync(Producto producto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Producto producto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
