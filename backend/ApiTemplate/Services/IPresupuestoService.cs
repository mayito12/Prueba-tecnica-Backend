using ApiTemplate.DTOs;

namespace ApiTemplate.Services;

public interface IPresupuestoService
{
    Task<IEnumerable<PresupuestoDto>> GetAllAsync();
    Task<PresupuestoDto?> GetByIdAsync(int id);
    Task<PresupuestoDto> CreateAsync(CreatePresupuestoDto dto);
    Task<PresupuestoDto?> UpdateEstadoAsync(int id, UpdatePresupuestoEstadoDto dto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<PresupuestoDto>> GetByClienteIdAsync(int clienteId);
}
