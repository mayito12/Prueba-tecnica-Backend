using Microsoft.AspNetCore.Mvc;
using ApiTemplate.DTOs;
using ApiTemplate.Services;

namespace ApiTemplate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
    {
        var clientes = await _clienteService.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDto>> GetById(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if (cliente == null)
            return NotFound(new { message = $"Cliente con ID {id} no encontrado." });
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> Create(CreateClienteDto dto)
    {
        var cliente = await _clienteService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ClienteDto>> Update(int id, UpdateClienteDto dto)
    {
        var cliente = await _clienteService.UpdateAsync(id, dto);
        if (cliente == null)
            return NotFound(new { message = $"Cliente con ID {id} no encontrado." });
        return Ok(cliente);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _clienteService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Cliente con ID {id} no encontrado." });
        return NoContent();
    }
}
