using Backend.DTOs.Clientes;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ClientesController(
    IClienteService service,
    ILogger<ClientesController> logger) : ApiControllerBase
{
    /// <summary>Obtiene todos los clientes activos.</summary>
    /// <returns>Lista de clientes.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ClienteDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ClienteDto>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener clientes");
            return Ok(await service.GetAllAsync(cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener clientes");
        }
    }

    /// <summary>Obtiene un cliente por su ID.</summary>
    /// <param name="id">ID del cliente.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Cliente encontrado o 404 si no existe.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener cliente {ClienteId}", id);
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener cliente");
        }
    }

    /// <summary>Crea un nuevo cliente.</summary>
    /// <param name="dto">Datos del cliente a crear.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Cliente creado con su ID asignado.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ClienteDto>> Create(
        [FromBody] CreateClienteDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para crear cliente");
            var cliente = await service.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "crear cliente");
        }
    }

    /// <summary>Actualiza un cliente existente.</summary>
    /// <param name="id">ID del cliente a actualizar.</param>
    /// <param name="dto">Datos actualizados del cliente.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Cliente actualizado o 404 si no existe.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ClienteDto>> Update(
        int id,
        [FromBody] UpdateClienteDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para actualizar cliente {ClienteId}", id);
            return Ok(await service.UpdateAsync(id, dto, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "actualizar cliente");
        }
    }

    /// <summary>Elimina (soft delete) un cliente.</summary>
    /// <param name="id">ID del cliente a eliminar.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>204 si se elimino correctamente, 404 si no existe.</returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para eliminar cliente {ClienteId}", id);
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "eliminar cliente");
        }
    }
}
