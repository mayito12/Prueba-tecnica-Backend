using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Servicios;

public sealed class CreateServicioDto
{
    [Required]
    [StringLength(200)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Range(typeof(decimal), "0", "79228162514264337593543950335")]
    public decimal PrecioPorHora { get; set; }
}
