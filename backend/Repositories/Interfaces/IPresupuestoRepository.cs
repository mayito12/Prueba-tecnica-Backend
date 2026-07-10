using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IPresupuestoRepository
{
    Task<IReadOnlyList<Presupuesto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Presupuesto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Presupuesto>> GetByClienteIdAsync(int clienteId, CancellationToken cancellationToken = default);
    Task<Presupuesto?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default);
    Task<Presupuesto> CreateAsync(Presupuesto presupuesto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Presupuesto presupuesto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
