using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Servicio> Servicios => Set<Servicio>();
    public DbSet<Presupuesto> Presupuestos => Set<Presupuesto>();
    public DbSet<PresupuestoProducto> PresupuestoProductos => Set<PresupuestoProducto>();
    public DbSet<PresupuestoServicio> PresupuestoServicios => Set<PresupuestoServicio>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Presupuesto>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Presupuestos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PresupuestoProducto>()
            .HasOne(pp => pp.Presupuesto)
            .WithMany(p => p.PresupuestoProductos)
            .HasForeignKey(pp => pp.PresupuestoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PresupuestoProducto>()
            .HasOne(pp => pp.Producto)
            .WithMany(p => p.PresupuestoProductos)
            .HasForeignKey(pp => pp.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PresupuestoServicio>()
            .HasOne(ps => ps.Presupuesto)
            .WithMany(p => p.PresupuestoServicios)
            .HasForeignKey(ps => ps.PresupuestoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PresupuestoServicio>()
            .HasOne(ps => ps.Servicio)
            .WithMany(s => s.PresupuestoServicios)
            .HasForeignKey(ps => ps.ServicioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
