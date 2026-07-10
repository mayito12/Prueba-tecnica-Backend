using ApiTemplate.Models;

namespace ApiTemplate.Repositories;

public interface IServicioRepository
{
    Task<IEnumerable<Servicio>> GetAllAsync();
    Task<Servicio?> GetByIdAsync(int id);
    Task<Servicio> AddAsync(Servicio servicio);
    Task<Servicio> UpdateAsync(Servicio servicio);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
