using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ILogger<ProductosController> _logger;

    public ProductosController(ILogger<ProductosController> logger)
    {
        _logger = logger;
    }

    /// <summary>Obtiene todos los productos activos.</summary>
    /// <returns>Lista de productos.</returns>
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            _logger.LogInformation("Obteniendo todos los productos");
            throw new NotImplementedException();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, new { message = "Endpoint no implementado." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener productos");
            return StatusCode(500, new { message = "Error interno del servidor." });
        }
    }

    /// <summary>Obtiene un producto por su ID.</summary>
    /// <param name="id">ID del producto.</param>
    /// <returns>Producto encontrado o 404 si no existe.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        try
        {
            _logger.LogInformation("Obteniendo producto {Id}", id);
            throw new NotImplementedException();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, new { message = "Endpoint no implementado." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener producto {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor." });
        }
    }

    /// <summary>Crea un nuevo producto.</summary>
    /// <param name="dto">Datos del producto a crear.</param>
    /// <returns>Producto creado con su ID asignado.</returns>
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] object dto)
    {
        try
        {
            _logger.LogInformation("Creando nuevo producto");
            throw new NotImplementedException();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, new { message = "Endpoint no implementado." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear producto");
            return StatusCode(500, new { message = "Error interno del servidor." });
        }
    }

    /// <summary>Actualiza un producto existente.</summary>
    /// <param name="id">ID del producto a actualizar.</param>
    /// <param name="dto">Datos actualizados del producto.</param>
    /// <returns>Producto actualizado o 404 si no existe.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] object dto)
    {
        try
        {
            _logger.LogInformation("Actualizando producto {Id}", id);
            throw new NotImplementedException();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, new { message = "Endpoint no implementado." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar producto {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor." });
        }
    }

    /// <summary>Elimina (soft delete) un producto.</summary>
    /// <param name="id">ID del producto a eliminar.</param>
    /// <returns>204 si se eliminó correctamente, 404 si no existe.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            _logger.LogInformation("Eliminando producto {Id}", id);
            throw new NotImplementedException();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, new { message = "Endpoint no implementado." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar producto {Id}", id);
            return StatusCode(500, new { message = "Error interno del servidor." });
        }
    }
}
