using ApiTemplate.Models;

namespace ApiTemplate.Repositories;

public interface IPresupuestoRepository
{
    Task<IEnumerable<Presupuesto>> GetAllAsync();
    Task<Presupuesto?> GetByIdAsync(int id);
    Task<Presupuesto> AddAsync(Presupuesto presupuesto);
    Task<Presupuesto> UpdateAsync(Presupuesto presupuesto);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<Presupuesto>> GetByClienteIdAsync(int clienteId);
}
