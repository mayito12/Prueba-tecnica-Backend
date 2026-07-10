using Backend.DTOs.Productos;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductosController(
    IProductoService service,
    ILogger<ProductosController> logger) : ApiControllerBase
{
    /// <summary>Obtiene todos los productos activos.</summary>
    /// <returns>Lista de productos.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ProductoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductoDto>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener productos");
            return Ok(await service.GetAllAsync(cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener productos");
        }
    }

    /// <summary>Obtiene un producto por su ID.</summary>
    /// <param name="id">ID del producto.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Producto encontrado o 404 si no existe.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoDto>> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener producto {ProductoId}", id);
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener producto");
        }
    }

    /// <summary>Crea un nuevo producto.</summary>
    /// <param name="dto">Datos del producto a crear.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Producto creado con su ID asignado.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProductoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> Create(
        [FromBody] CreateProductoDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para crear producto");
            var producto = await service.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "crear producto");
        }
    }

    /// <summary>Actualiza un producto existente.</summary>
    /// <param name="id">ID del producto a actualizar.</param>
    /// <param name="dto">Datos actualizados del producto.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Producto actualizado o 404 si no existe.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ProductoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoDto>> Update(
        int id,
        [FromBody] UpdateProductoDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para actualizar producto {ProductoId}", id);
            return Ok(await service.UpdateAsync(id, dto, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "actualizar producto");
        }
    }

    /// <summary>Elimina (soft delete) un producto.</summary>
    /// <param name="id">ID del producto a eliminar.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>204 si se elimino correctamente, 404 si no existe.</returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para eliminar producto {ProductoId}", id);
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "eliminar producto");
        }
    }
}
