using System.ComponentModel.DataAnnotations;

namespace ApiTemplate.DTOs;

public class ServicioDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal PrecioPorHora { get; set; }
    public DateTime FechaCreacion { get; set; }
}

public class CreateServicioDto
{
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Descripcion { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal PrecioPorHora { get; set; }
}

public class UpdateServicioDto
{
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Descripcion { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal PrecioPorHora { get; set; }
}
