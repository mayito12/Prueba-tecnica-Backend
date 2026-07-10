using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Presupuestos;

public sealed class UpdateEstadoDto
{
    [Required]
    [RegularExpression("^(Pendiente|Aprobado|Rechazado)$")]
    public string Estado { get; set; } = string.Empty;
}
