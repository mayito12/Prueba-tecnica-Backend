using System.ComponentModel.DataAnnotations;

namespace ApiTemplate.Models;

public enum TipoItem
{
    Producto,
    Servicio
}

public class PresupuestoDetalle
{
    public int Id { get; set; }

    [Required]
    public int PresupuestoId { get; set; }

    public Presupuesto Presupuesto { get; set; } = null!;

    [Required]
    public TipoItem TipoItem { get; set; }

    public int ItemId { get; set; }

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PrecioUnitario { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Subtotal { get; set; }
}
