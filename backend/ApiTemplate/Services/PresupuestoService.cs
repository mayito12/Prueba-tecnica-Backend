using ApiTemplate.DTOs;
using ApiTemplate.Models;
using ApiTemplate.Repositories;

namespace ApiTemplate.Services;

public class PresupuestoService : IPresupuestoService
{
    private readonly IPresupuestoRepository _presupuestoRepository;
    private readonly IProductoRepository _productoRepository;
    private readonly IServicioRepository _servicioRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly ILogger<PresupuestoService> _logger;

    public PresupuestoService(
        IPresupuestoRepository presupuestoRepository,
        IProductoRepository productoRepository,
        IServicioRepository servicioRepository,
        IClienteRepository clienteRepository,
        ILogger<PresupuestoService> logger)
    {
        _presupuestoRepository = presupuestoRepository;
        _productoRepository = productoRepository;
        _servicioRepository = servicioRepository;
        _clienteRepository = clienteRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<PresupuestoDto>> GetAllAsync()
    {
        var presupuestos = await _presupuestoRepository.GetAllAsync();
        return presupuestos.Select(MapToDto);
    }

    public async Task<PresupuestoDto?> GetByIdAsync(int id)
    {
        var presupuesto = await _presupuestoRepository.GetByIdAsync(id);
        return presupuesto == null ? null : MapToDto(presupuesto);
    }

    public async Task<PresupuestoDto> CreateAsync(CreatePresupuestoDto dto)
    {
        if (!await _clienteRepository.ExistsAsync(dto.ClienteId))
            throw new KeyNotFoundException($"Cliente con ID {dto.ClienteId} no encontrado.");

        var presupuesto = new Presupuesto
        {
            ClienteId = dto.ClienteId,
            Estado = EstadoPresupuesto.Pendiente
        };

        foreach (var detalleDto in dto.Detalles)
        {
            var (precioUnitario, descripcion) = await ObtenerPrecioItem(detalleDto);
            var subtotal = precioUnitario * detalleDto.Cantidad;

            presupuesto.Detalles.Add(new PresupuestoDetalle
            {
                TipoItem = Enum.Parse<TipoItem>(detalleDto.TipoItem),
                ItemId = detalleDto.ItemId,
                Cantidad = detalleDto.Cantidad,
                PrecioUnitario = precioUnitario,
                Subtotal = subtotal
            });

            presupuesto.Total += subtotal;
        }

        var created = await _presupuestoRepository.AddAsync(presupuesto);
        _logger.LogInformation("Presupuesto creado: {Id} - Total: {Total}", created.Id, created.Total);
        return MapToDto(created);
    }

    public async Task<PresupuestoDto?> UpdateEstadoAsync(int id, UpdatePresupuestoEstadoDto dto)
    {
        var presupuesto = await _presupuestoRepository.GetByIdAsync(id);
        if (presupuesto == null) return null;

        if (!Enum.TryParse<EstadoPresupuesto>(dto.Estado, true, out var nuevoEstado))
            throw new ArgumentException($"Estado inválido: {dto.Estado}. Valores permitidos: Pendiente, Aprobado, Rechazado.");

        presupuesto.Estado = nuevoEstado;
        var updated = await _presupuestoRepository.UpdateAsync(presupuesto);
        _logger.LogInformation("Presupuesto {Id} actualizado a estado: {Estado}", updated.Id, updated.Estado);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _presupuestoRepository.DeleteAsync(id);
        if (deleted)
            _logger.LogInformation("Presupuesto eliminado: {Id}", id);
        return deleted;
    }

    public async Task<IEnumerable<PresupuestoDto>> GetByClienteIdAsync(int clienteId)
    {
        var presupuestos = await _presupuestoRepository.GetByClienteIdAsync(clienteId);
        return presupuestos.Select(MapToDto);
    }

    private async Task<(decimal Precio, string Descripcion)> ObtenerPrecioItem(CreatePresupuestoDetalleDto detalle)
    {
        if (detalle.TipoItem == nameof(TipoItem.Producto))
        {
            var producto = await _productoRepository.GetByIdAsync(detalle.ItemId)
                ?? throw new KeyNotFoundException($"Producto con ID {detalle.ItemId} no encontrado.");
            return (producto.Precio, producto.Nombre);
        }
        else if (detalle.TipoItem == nameof(TipoItem.Servicio))
        {
            var servicio = await _servicioRepository.GetByIdAsync(detalle.ItemId)
                ?? throw new KeyNotFoundException($"Servicio con ID {detalle.ItemId} no encontrado.");
            return (servicio.PrecioPorHora, servicio.Nombre);
        }

        throw new ArgumentException($"Tipo de item inválido: {detalle.TipoItem}");
    }

    private static PresupuestoDto MapToDto(Presupuesto presupuesto) => new()
    {
        Id = presupuesto.Id,
        ClienteId = presupuesto.ClienteId,
        ClienteNombre = presupuesto.Cliente?.Nombre ?? "",
        FechaCreacion = presupuesto.FechaCreacion,
        Total = presupuesto.Total,
        Estado = presupuesto.Estado.ToString(),
        Detalles = presupuesto.Detalles.Select(d => new PresupuestoDetalleDto
        {
            Id = d.Id,
            TipoItem = d.TipoItem.ToString(),
            ItemId = d.ItemId,
            Cantidad = d.Cantidad,
            PrecioUnitario = d.PrecioUnitario,
            Subtotal = d.Subtotal
        }).ToList()
    };
}
