using Microsoft.AspNetCore.Mvc;
using ApiTemplate.DTOs;
using ApiTemplate.Services;

namespace ApiTemplate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
    {
        var productos = await _productoService.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDto>> GetById(int id)
    {
        var producto = await _productoService.GetByIdAsync(id);
        if (producto == null)
            return NotFound(new { message = $"Producto con ID {id} no encontrado." });
        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult<ProductoDto>> Create(CreateProductoDto dto)
    {
        var producto = await _productoService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductoDto>> Update(int id, UpdateProductoDto dto)
    {
        var producto = await _productoService.UpdateAsync(id, dto);
        if (producto == null)
            return NotFound(new { message = $"Producto con ID {id} no encontrado." });
        return Ok(producto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _productoService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Producto con ID {id} no encontrado." });
        return NoContent();
    }
}
