using Backend.DTOs.Servicios;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ServiciosController(
    IServicioService service,
    ILogger<ServiciosController> logger) : ApiControllerBase
{
    /// <summary>Obtiene todos los servicios activos.</summary>
    /// <returns>Lista de servicios.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ServicioDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ServicioDto>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener servicios");
            return Ok(await service.GetAllAsync(cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener servicios");
        }
    }

    /// <summary>Obtiene un servicio por su ID.</summary>
    /// <param name="id">ID del servicio.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Servicio encontrado o 404 si no existe.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ServicioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServicioDto>> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para obtener servicio {ServicioId}", id);
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "obtener servicio");
        }
    }

    /// <summary>Crea un nuevo servicio.</summary>
    /// <param name="dto">Datos del servicio a crear.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Servicio creado con su ID asignado.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ServicioDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServicioDto>> Create(
        [FromBody] CreateServicioDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para crear servicio");
            var servicio = await service.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = servicio.Id }, servicio);
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "crear servicio");
        }
    }

    /// <summary>Actualiza un servicio existente.</summary>
    /// <param name="id">ID del servicio a actualizar.</param>
    /// <param name="dto">Datos actualizados del servicio.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>Servicio actualizado o 404 si no existe.</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ServicioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServicioDto>> Update(
        int id,
        [FromBody] UpdateServicioDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para actualizar servicio {ServicioId}", id);
            return Ok(await service.UpdateAsync(id, dto, cancellationToken));
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "actualizar servicio");
        }
    }

    /// <summary>Elimina (soft delete) un servicio.</summary>
    /// <param name="id">ID del servicio a eliminar.</param>
    /// <param name="cancellationToken">Token de cancelacion de la solicitud.</param>
    /// <returns>204 si se elimino correctamente, 404 si no existe.</returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Procesando solicitud para eliminar servicio {ServicioId}", id);
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception exception)
        {
            return HandleException(exception, logger, "eliminar servicio");
        }
    }
}
