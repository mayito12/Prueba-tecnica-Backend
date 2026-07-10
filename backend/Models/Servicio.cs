using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Servicio
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Descripcion { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PrecioPorHora { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public bool Activo { get; set; } = true;

    public ICollection<PresupuestoServicio> PresupuestoServicios { get; set; } = new List<PresupuestoServicio>();
}
