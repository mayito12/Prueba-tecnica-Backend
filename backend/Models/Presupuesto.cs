using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public enum EstadoPresupuesto
{
    Pendiente,
    Aprobado,
    Rechazado
}

public class Presupuesto
{
    public int Id { get; set; }

    [Required]
    public int ClienteId { get; set; }

    public Cliente Cliente { get; set; } = null!;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    [Range(0, double.MaxValue)]
    public decimal Total { get; set; }

    public EstadoPresupuesto Estado { get; set; } = EstadoPresupuesto.Pendiente;

    public ICollection<PresupuestoProducto> PresupuestoProductos { get; set; } = new List<PresupuestoProducto>();
    public ICollection<PresupuestoServicio> PresupuestoServicios { get; set; } = new List<PresupuestoServicio>();
}
