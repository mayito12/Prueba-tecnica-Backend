using Backend.DTOs.Presupuestos;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PresupuestosController(
    IPresupuestoService service,
    ILogger<PresupuestosController> logger) : ApiControllerBase
{
    /// <summary>Obtiene todos los presupuestos.</summary>
    /// <returns>Lista de presupuestos.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PresupuestoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PresupuestoDto>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener presupuestos");
            return Ok(await service.GetAllAsync(cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener presupuestos");
        }
    }

    /// <summary>Obtiene un presupuesto por su ID.</summary>
    /// <param name="id">ID del presupuesto.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Presupuesto encontrado o 404 si no existe.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(PresupuestoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresupuestoDto>> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener presupuesto {PresupuestoId}", id);
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener presupuesto");
        }
    }

    /// <summary>Crea un nuevo presupuesto con sus productos y servicios asociados.</summary>
    /// <param name="dto">Datos del presupuesto incluyendo productos y servicios.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Presupuesto creado con su ID asignado.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PresupuestoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresupuestoDto>> Create(
        [FromBody] CreatePresupuestoDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para crear presupuesto");
            var presupuesto = await service.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = presupuesto.Id }, presupuesto);
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "crear presupuesto");
        }
    }

    /// <summary>Actualiza el estado de un presupuesto (Pendiente/Aprobado/Rechazado).</summary>
    /// <param name="id">ID del presupuesto.</param>
    /// <param name="dto">Nuevo estado del presupuesto.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Presupuesto actualizado o 404 si no existe.</returns>
    [HttpPatch("{id:int}/estado")]
    [ProducesResponseType(typeof(PresupuestoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresupuestoDto>> UpdateEstado(
        int id,
        [FromBody] UpdateEstadoDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para actualizar estado del presupuesto {PresupuestoId}", id);
            return Ok(await service.UpdateEstadoAsync(id, dto, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "actualizar estado de presupuesto");
        }
    }

    /// <summary>Elimina un presupuesto.</summary>
    /// <param name="id">ID del presupuesto a eliminar.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>204 si se elimino correctamente, 404 si no existe.</returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para eliminar presupuesto {PresupuestoId}", id);
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "eliminar presupuesto");
        }
    }

    /// <summary>Obtiene todos los presupuestos de un cliente especifico.</summary>
    /// <param name="clienteId">ID del cliente.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Lista de presupuestos del cliente.</returns>
    [HttpGet("cliente/{clienteId:int}")]
    [ProducesResponseType(typeof(IReadOnlyList<PresupuestoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PresupuestoDto>>> GetByClienteId(
        int clienteId,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud de presupuestos del cliente {ClienteId}", clienteId);
            return Ok(await service.GetByClienteIdAsync(clienteId, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener presupuestos por cliente");
        }
    }
}
