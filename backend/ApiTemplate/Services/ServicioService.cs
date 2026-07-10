using ApiTemplate.DTOs;
using ApiTemplate.Models;
using ApiTemplate.Repositories;

namespace ApiTemplate.Services;

public class ServicioService : IServicioService
{
    private readonly IServicioRepository _repository;
    private readonly ILogger<ServicioService> _logger;

    public ServicioService(IServicioRepository repository, ILogger<ServicioService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<ServicioDto>> GetAllAsync()
    {
        var servicios = await _repository.GetAllAsync();
        return servicios.Select(MapToDto);
    }

    public async Task<ServicioDto?> GetByIdAsync(int id)
    {
        var servicio = await _repository.GetByIdAsync(id);
        return servicio == null ? null : MapToDto(servicio);
    }

    public async Task<ServicioDto> CreateAsync(CreateServicioDto dto)
    {
        var servicio = new Servicio
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            PrecioPorHora = dto.PrecioPorHora
        };

        var created = await _repository.AddAsync(servicio);
        _logger.LogInformation("Servicio creado: {Id} - {Nombre}", created.Id, created.Nombre);
        return MapToDto(created);
    }

    public async Task<ServicioDto?> UpdateAsync(int id, UpdateServicioDto dto)
    {
        var servicio = await _repository.GetByIdAsync(id);
        if (servicio == null) return null;

        servicio.Nombre = dto.Nombre;
        servicio.Descripcion = dto.Descripcion;
        servicio.PrecioPorHora = dto.PrecioPorHora;

        var updated = await _repository.UpdateAsync(servicio);
        _logger.LogInformation("Servicio actualizado: {Id}", updated.Id);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (deleted)
            _logger.LogInformation("Servicio eliminado: {Id}", id);
        return deleted;
    }

    private static ServicioDto MapToDto(Servicio servicio) => new()
    {
        Id = servicio.Id,
        Nombre = servicio.Nombre,
        Descripcion = servicio.Descripcion,
        PrecioPorHora = servicio.PrecioPorHora,
        FechaCreacion = servicio.FechaCreacion
    };
}
