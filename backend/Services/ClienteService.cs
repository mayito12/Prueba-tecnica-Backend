using AutoMapper;
using Backend.Common.Exceptions;
using Backend.Common.Validation;
using Backend.DTOs.Clientes;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public sealed class ClienteService(
    IClienteRepository repository,
    IMapper mapper,
    ILogger<ClienteService> logger) : IClienteService
{
    public async Task<IReadOnlyList<ClienteDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Iniciando consulta de clientes");
            var clientes = await repository.GetAllAsync<ClienteDto>(mapper.ConfigurationProvider, cancellationToken);
            logger.LogInformation("Consulta de clientes completada con {Cantidad} registros", clientes.Count);
            return clientes;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar clientes");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar clientes", "No fue posible obtener los clientes.");
        }
    }

    public async Task<ClienteDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "cliente");
            logger.LogInformation("Iniciando consulta del cliente {ClienteId}", id);

            var cliente = await repository.GetByIdAsync<ClienteDto>(id, mapper.ConfigurationProvider, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el cliente {id}.");

            logger.LogInformation("Consulta del cliente {ClienteId} completada", id);
            return cliente;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "consultar cliente");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "consultar cliente", $"No fue posible obtener el cliente {id}.");
        }
    }

    public async Task<ClienteDto> CreateAsync(CreateClienteDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Iniciando creacion de cliente");
            var normalizedEmail = TextNormalizer.ForComparison(dto.Email);

            if (await repository.EmailExistsAsync(normalizedEmail, cancellationToken: cancellationToken))
            {
                throw new ConflictException("Ya existe un cliente activo con el correo indicado.");
            }

            var cliente = mapper.Map<Cliente>(dto);
            Normalize(cliente, dto.Nombre, dto.Email, dto.Telefono, dto.Direccion);
            cliente.FechaCreacion = DateTime.UtcNow;
            cliente.Activo = true;

            await repository.CreateAsync(cliente, cancellationToken);
            logger.LogInformation("Cliente {ClienteId} creado correctamente", cliente.Id);
            return mapper.Map<ClienteDto>(cliente);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "crear cliente");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "crear cliente", "No fue posible crear el cliente.");
        }
    }

    public async Task<ClienteDto> UpdateAsync(
        int id,
        UpdateClienteDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "cliente");
            logger.LogInformation("Iniciando actualizacion del cliente {ClienteId}", id);

            var cliente = await repository.GetForUpdateAsync(id, cancellationToken)
                ?? throw new NotFoundException($"No se encontro el cliente {id}.");

            var normalizedEmail = TextNormalizer.ForComparison(dto.Email);
            if (await repository.EmailExistsAsync(normalizedEmail, id, cancellationToken))
            {
                throw new ConflictException("Ya existe otro cliente activo con el correo indicado.");
            }

            mapper.Map(dto, cliente);
            Normalize(cliente, dto.Nombre, dto.Email, dto.Telefono, dto.Direccion);
            await repository.UpdateAsync(cliente, cancellationToken);

            logger.LogInformation("Cliente {ClienteId} actualizado correctamente", id);
            return mapper.Map<ClienteDto>(cliente);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "actualizar cliente");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "actualizar cliente", $"No fue posible actualizar el cliente {id}.");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            Guard.PositiveId(id, "cliente");
            logger.LogInformation("Iniciando eliminacion logica del cliente {ClienteId}", id);

            if (!await repository.DeleteAsync(id, cancellationToken))
            {
                throw new NotFoundException($"No se encontro el cliente {id}.");
            }

            logger.LogInformation("Cliente {ClienteId} eliminado logicamente", id);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception) when (IsBusinessException(exception))
        {
            LogBusinessException(exception, "eliminar cliente");
            throw;
        }
        catch (Exception exception)
        {
            throw WrapException(exception, "eliminar cliente", $"No fue posible eliminar el cliente {id}.");
        }
    }

    private static void Normalize(
        Cliente cliente,
        string nombre,
        string email,
        string? telefono,
        string? direccion)
    {
        cliente.Nombre = TextNormalizer.Required(nombre);
        cliente.Email = TextNormalizer.Required(email);
        cliente.Telefono = TextNormalizer.Optional(telefono);
        cliente.Direccion = TextNormalizer.Optional(direccion);
    }

    private static bool IsBusinessException(Exception exception) =>
        exception is NotFoundException or BusinessValidationException or ConflictException;

    private void LogBusinessException(Exception exception, string operation)
    {
        logger.LogWarning("No se pudo {Operacion}: {Message}", operation, exception.Message);
    }

    private ServiceException WrapException(Exception exception, string operation, string clientMessage)
    {
        if (exception is RepositoryException)
        {
            logger.LogWarning("Fallo de repositorio al {Operacion}: {Message}", operation, exception.Message);
        }
        else
        {
            logger.LogError(exception, "Error inesperado al {Operacion}", operation);
        }

        return new ServiceException(clientMessage, exception);
    }
}
