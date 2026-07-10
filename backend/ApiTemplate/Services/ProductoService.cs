using ApiTemplate.DTOs;
using ApiTemplate.Models;
using ApiTemplate.Repositories;

namespace ApiTemplate.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;
    private readonly ILogger<ProductoService> _logger;

    public ProductoService(IProductoRepository repository, ILogger<ProductoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<ProductoDto>> GetAllAsync()
    {
        var productos = await _repository.GetAllAsync();
        return productos.Select(MapToDto);
    }

    public async Task<ProductoDto?> GetByIdAsync(int id)
    {
        var producto = await _repository.GetByIdAsync(id);
        return producto == null ? null : MapToDto(producto);
    }

    public async Task<ProductoDto> CreateAsync(CreateProductoDto dto)
    {
        var producto = new Producto
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Precio = dto.Precio,
            Stock = dto.Stock
        };

        var created = await _repository.AddAsync(producto);
        _logger.LogInformation("Producto creado: {Id} - {Nombre}", created.Id, created.Nombre);
        return MapToDto(created);
    }

    public async Task<ProductoDto?> UpdateAsync(int id, UpdateProductoDto dto)
    {
        var producto = await _repository.GetByIdAsync(id);
        if (producto == null) return null;

        producto.Nombre = dto.Nombre;
        producto.Descripcion = dto.Descripcion;
        producto.Precio = dto.Precio;
        producto.Stock = dto.Stock;

        var updated = await _repository.UpdateAsync(producto);
        _logger.LogInformation("Producto actualizado: {Id}", updated.Id);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (deleted)
            _logger.LogInformation("Producto eliminado: {Id}", id);
        return deleted;
    }

    private static ProductoDto MapToDto(Producto producto) => new()
    {
        Id = producto.Id,
        Nombre = producto.Nombre,
        Descripcion = producto.Descripcion,
        Precio = producto.Precio,
        Stock = producto.Stock,
        FechaCreacion = producto.FechaCreacion
    };
}
