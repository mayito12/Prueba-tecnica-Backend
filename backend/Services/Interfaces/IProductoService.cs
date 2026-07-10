using Backend.DTOs.Productos;

namespace Backend.Services.Interfaces;

public interface IProductoService
{
    Task<IReadOnlyList<ProductoDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ProductoDto> CreateAsync(CreateProductoDto dto, CancellationToken cancellationToken = default);
    Task<ProductoDto> UpdateAsync(int id, UpdateProductoDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
