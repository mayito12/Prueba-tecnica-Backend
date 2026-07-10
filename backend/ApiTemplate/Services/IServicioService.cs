using ApiTemplate.DTOs;

namespace ApiTemplate.Services;

public interface IServicioService
{
    Task<IEnumerable<ServicioDto>> GetAllAsync();
    Task<ServicioDto?> GetByIdAsync(int id);
    Task<ServicioDto> CreateAsync(CreateServicioDto dto);
    Task<ServicioDto?> UpdateAsync(int id, UpdateServicioDto dto);
    Task<bool> DeleteAsync(int id);
}
