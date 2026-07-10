using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<IReadOnlyList<TProjection>> GetAllAsync<TProjection>(
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default);

    Task<TProjection?> GetByIdAsync<TProjection>(
        int id,
        AutoMapper.IConfigurationProvider mappingConfiguration,
        CancellationToken cancellationToken = default);

    Task<Cliente?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> ExistsActiveAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> EmailExistsAsync(string normalizedEmail, int? excludedId = null, CancellationToken cancellationToken = default);
    Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default);
    Task UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
