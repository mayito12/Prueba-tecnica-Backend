using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Presupuestos;

public sealed class CreatePresupuestoDto
{
    [Range(1, int.MaxValue)]
    public int ClienteId { get; set; }

    [Required]
    [MinLength(1)]
    public List<CreatePresupuestoItemDto> Items { get; set; } = [];
}

public sealed class CreatePresupuestoItemDto
{
    [Required]
    [RegularExpression("^(Producto|Servicio)$")]
    public string Tipo { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int ItemId { get; set; }

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }
}
