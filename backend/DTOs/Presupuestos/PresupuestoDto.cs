namespace Backend.DTOs.Presupuestos;

public sealed class PresupuestoDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = string.Empty;
    public List<PresupuestoItemDto> Items { get; set; } = [];
}

public sealed class PresupuestoItemDto
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int ItemId { get; set; }
    public string NombreItem { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}
