namespace Backend.DTOs.Servicios;

public sealed class ServicioDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal PrecioPorHora { get; set; }
    public DateTime FechaCreacion { get; set; }
}
