using Backend.DTOs.Presupuestos;

namespace Backend.Services.Interfaces;

public interface IPresupuestoService
{
    Task<IReadOnlyList<PresupuestoDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PresupuestoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PresupuestoDto> CreateAsync(CreatePresupuestoDto dto, CancellationToken cancellationToken = default);
    Task<PresupuestoDto> UpdateEstadoAsync(int id, UpdateEstadoDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PresupuestoDto>> GetByClienteIdAsync(int clienteId, CancellationToken cancellationToken = default);
}
