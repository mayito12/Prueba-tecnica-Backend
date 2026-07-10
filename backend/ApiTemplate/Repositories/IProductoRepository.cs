using ApiTemplate.Models;

namespace ApiTemplate.Repositories;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<Producto> AddAsync(Producto producto);
    Task<Producto> UpdateAsync(Producto producto);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
