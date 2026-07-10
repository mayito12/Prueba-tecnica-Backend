using Backend.DTOs.Clientes;

namespace Backend.Services.Interfaces;

public interface IClienteService
{
    Task<IReadOnlyList<ClienteDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ClienteDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ClienteDto> CreateAsync(CreateClienteDto dto, CancellationToken cancellationToken = default);
    Task<ClienteDto> UpdateAsync(int id, UpdateClienteDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
