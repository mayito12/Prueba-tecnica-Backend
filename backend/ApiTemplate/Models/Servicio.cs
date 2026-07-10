using System.ComponentModel.DataAnnotations;

namespace ApiTemplate.Models;

public class Servicio
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Descripcion { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PrecioPorHora { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
