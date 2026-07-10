using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IServicioRepository
{
    Task<IReadOnlyList<TProjection>> GetAllAsync<TProjection>(
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default);

    Task<TProjection?> GetByIdAsync<TProjection>(
        int id,
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default);

    Task<Servicio?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyDictionary<int, Servicio>> GetActiveByIdsAsync(
        IEnumerable<int> ids,
        CancellationToken cancellationToken = default);

    Task<Servicio> CreateAsync(Servicio servicio, CancellationToken cancellationToken = default);
    Task UpdateAsync(Servicio servicio, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
