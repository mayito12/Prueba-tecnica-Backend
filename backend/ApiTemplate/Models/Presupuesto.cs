using System.ComponentModel.DataAnnotations;

namespace ApiTemplate.Models;

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

    public ICollection<PresupuestoDetalle> Detalles { get; set; } = new List<PresupuestoDetalle>();
}
