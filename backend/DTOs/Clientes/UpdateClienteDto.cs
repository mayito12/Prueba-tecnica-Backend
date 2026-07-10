using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Clientes;

public sealed class UpdateClienteDto
{
    [Required]
    [StringLength(200)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Telefono { get; set; }

    [StringLength(500)]
    public string? Direccion { get; set; }
}
