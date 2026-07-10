using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class PresupuestoServicio
{
    public int Id { get; set; }

    [Required]
    public int PresupuestoId { get; set; }
    public Presupuesto Presupuesto { get; set; } = null!;

    [Required]
    public int ServicioId { get; set; }
    public Servicio Servicio { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PrecioUnitario { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Subtotal { get; set; }
}
