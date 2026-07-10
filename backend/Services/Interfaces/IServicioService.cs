using Backend.DTOs.Servicios;

namespace Backend.Services.Interfaces;

public interface IServicioService
{
    Task<IReadOnlyList<ServicioDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ServicioDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ServicioDto> CreateAsync(CreateServicioDto dto, CancellationToken cancellationToken = default);
    Task<ServicioDto> UpdateAsync(int id, UpdateServicioDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
