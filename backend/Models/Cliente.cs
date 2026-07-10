using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Telefono { get; set; }

    [MaxLength(500)]
    public string? Direccion { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public bool Activo { get; set; } = true;

    public ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();
}
