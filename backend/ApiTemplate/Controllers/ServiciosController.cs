using Microsoft.AspNetCore.Mvc;
using ApiTemplate.DTOs;
using ApiTemplate.Services;

namespace ApiTemplate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiciosController : ControllerBase
{
    private readonly IServicioService _servicioService;

    public ServiciosController(IServicioService servicioService)
    {
        _servicioService = servicioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServicioDto>>> GetAll()
    {
        var servicios = await _servicioService.GetAllAsync();
        return Ok(servicios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServicioDto>> GetById(int id)
    {
        var servicio = await _servicioService.GetByIdAsync(id);
        if (servicio == null)
            return NotFound(new { message = $"Servicio con ID {id} no encontrado." });
        return Ok(servicio);
    }

    [HttpPost]
    public async Task<ActionResult<ServicioDto>> Create(CreateServicioDto dto)
    {
        var servicio = await _servicioService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = servicio.Id }, servicio);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServicioDto>> Update(int id, UpdateServicioDto dto)
    {
        var servicio = await _servicioService.UpdateAsync(id, dto);
        if (servicio == null)
            return NotFound(new { message = $"Servicio con ID {id} no encontrado." });
        return Ok(servicio);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _servicioService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Servicio con ID {id} no encontrado." });
        return NoContent();
    }
}
