using Backend.Common.Errors;
using Backend.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    protected ActionResult HandleException(Exception exception, ILogger logger, string operation)
    {
        switch (exception)
        {
            case BusinessValidationException:
                logger.LogWarning("Solicitud invalida al {Operacion}: {Message}", operation, exception.Message);
                return BadRequest(CreateError(exception.Message));

            case NotFoundException:
                logger.LogWarning("Recurso no encontrado al {Operacion}: {Message}", operation, exception.Message);
                return NotFound(CreateError(exception.Message));

            case ConflictException:
                logger.LogWarning("Conflicto al {Operacion}: {Message}", operation, exception.Message);
                return Conflict(CreateError(exception.Message));

            case OperationCanceledException:
                logger.LogWarning("Solicitud cancelada al {Operacion}", operation);
                return StatusCode(
                    StatusCodes.Status408RequestTimeout,
                    CreateError("La solicitud fue cancelada antes de completarse."));

            case ServiceException:
                logger.LogError(exception, "Error de servicio al {Operacion}", operation);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    CreateError(exception.Message));

            default:
                logger.LogError(exception, "Error inesperado al {Operacion}", operation);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    CreateError("Ocurrio un error interno al procesar la solicitud."));
        }
    }

    private ApiErrorResponse CreateError(string message) =>
        new(message, HttpContext.TraceIdentifier);
}
