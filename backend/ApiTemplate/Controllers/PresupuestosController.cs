using Microsoft.AspNetCore.Mvc;
using ApiTemplate.DTOs;
using ApiTemplate.Services;

namespace ApiTemplate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresupuestosController : ControllerBase
{
    private readonly IPresupuestoService _presupuestoService;

    public PresupuestosController(IPresupuestoService presupuestoService)
    {
        _presupuestoService = presupuestoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PresupuestoDto>>> GetAll()
    {
        var presupuestos = await _presupuestoService.GetAllAsync();
        return Ok(presupuestos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PresupuestoDto>> GetById(int id)
    {
        var presupuesto = await _presupuestoService.GetByIdAsync(id);
        if (presupuesto == null)
            return NotFound(new { message = $"Presupuesto con ID {id} no encontrado." });
        return Ok(presupuesto);
    }

    [HttpPost]
    public async Task<ActionResult<PresupuestoDto>> Create(CreatePresupuestoDto dto)
    {
        try
        {
            var presupuesto = await _presupuestoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = presupuesto.Id }, presupuesto);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{id}/estado")]
    public async Task<ActionResult<PresupuestoDto>> UpdateEstado(int id, UpdatePresupuestoEstadoDto dto)
    {
        try
        {
            var presupuesto = await _presupuestoService.UpdateEstadoAsync(id, dto);
            if (presupuesto == null)
                return NotFound(new { message = $"Presupuesto con ID {id} no encontrado." });
            return Ok(presupuesto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _presupuestoService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Presupuesto con ID {id} no encontrado." });
        return NoContent();
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<ActionResult<IEnumerable<PresupuestoDto>>> GetByClienteId(int clienteId)
    {
        var presupuestos = await _presupuestoService.GetByClienteIdAsync(clienteId);
        return Ok(presupuestos);
    }
}
