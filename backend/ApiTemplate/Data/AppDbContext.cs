using Microsoft.EntityFrameworkCore;
using ApiTemplate.Models;

namespace ApiTemplate.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Servicio> Servicios => Set<Servicio>();
    public DbSet<Presupuesto> Presupuestos => Set<Presupuesto>();
    public DbSet<PresupuestoDetalle> PresupuestoDetalles => Set<PresupuestoDetalle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Presupuesto>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Presupuestos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PresupuestoDetalle>()
            .HasOne(pd => pd.Presupuesto)
            .WithMany(p => p.Detalles)
            .HasForeignKey(pd => pd.PresupuestoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
