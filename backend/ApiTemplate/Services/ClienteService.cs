using ApiTemplate.DTOs;
using ApiTemplate.Models;
using ApiTemplate.Repositories;

namespace ApiTemplate.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    private readonly ILogger<ClienteService> _logger;

    public ClienteService(IClienteRepository repository, ILogger<ClienteService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();
        return clientes.Select(MapToDto);
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        return cliente == null ? null : MapToDto(cliente);
    }

    public async Task<ClienteDto> CreateAsync(CreateClienteDto dto)
    {
        var cliente = new Cliente
        {
            Nombre = dto.Nombre,
            Email = dto.Email,
            Telefono = dto.Telefono,
            Direccion = dto.Direccion
        };

        var created = await _repository.AddAsync(cliente);
        _logger.LogInformation("Cliente creado: {Id} - {Nombre}", created.Id, created.Nombre);
        return MapToDto(created);
    }

    public async Task<ClienteDto?> UpdateAsync(int id, UpdateClienteDto dto)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null) return null;

        cliente.Nombre = dto.Nombre;
        cliente.Email = dto.Email;
        cliente.Telefono = dto.Telefono;
        cliente.Direccion = dto.Direccion;

        var updated = await _repository.UpdateAsync(cliente);
        _logger.LogInformation("Cliente actualizado: {Id}", updated.Id);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (deleted)
            _logger.LogInformation("Cliente eliminado: {Id}", id);
        return deleted;
    }

    private static ClienteDto MapToDto(Cliente cliente) => new()
    {
        Id = cliente.Id,
        Nombre = cliente.Nombre,
        Email = cliente.Email,
        Telefono = cliente.Telefono,
        Direccion = cliente.Direccion,
        FechaCreacion = cliente.FechaCreacion
    };
}
