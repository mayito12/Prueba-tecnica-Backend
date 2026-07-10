using System.ComponentModel.DataAnnotations;
using ApiTemplate.Models;

namespace ApiTemplate.DTOs;

public class PresupuestoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = string.Empty;
    public List<PresupuestoDetalleDto> Detalles { get; set; } = new();
}

public class PresupuestoDetalleDto
{
    public int Id { get; set; }
    public string TipoItem { get; set; } = string.Empty;
    public int ItemId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}

public class CreatePresupuestoDto
{
    [Required]
    public int ClienteId { get; set; }

    [Required]
    [MinLength(1)]
    public List<CreatePresupuestoDetalleDto> Detalles { get; set; } = new();
}

public class CreatePresupuestoDetalleDto
{
    [Required]
    public string TipoItem { get; set; } = string.Empty;

    [Required]
    public int ItemId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }
}

public class UpdatePresupuestoEstadoDto
{
    [Required]
    public string Estado { get; set; } = string.Empty;
}
