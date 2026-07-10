using Microsoft.EntityFrameworkCore;
using ApiTemplate.Data;
using ApiTemplate.Models;

namespace ApiTemplate.Repositories;

public class PresupuestoRepository : IPresupuestoRepository
{
    private readonly AppDbContext _context;

    public PresupuestoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Presupuesto>> GetAllAsync()
    {
        return await _context.Presupuestos
            .Include(p => p.Cliente)
            .Include(p => p.Detalles)
            .OrderByDescending(p => p.FechaCreacion)
            .ToListAsync();
    }

    public async Task<Presupuesto?> GetByIdAsync(int id)
    {
        return await _context.Presupuestos
            .Include(p => p.Cliente)
            .Include(p => p.Detalles)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Presupuesto> AddAsync(Presupuesto presupuesto)
    {
        _context.Presupuestos.Add(presupuesto);
        await _context.SaveChangesAsync();
        return presupuesto;
    }

    public async Task<Presupuesto> UpdateAsync(Presupuesto presupuesto)
    {
        _context.Entry(presupuesto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return presupuesto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var presupuesto = await _context.Presupuestos.FindAsync(id);
        if (presupuesto == null) return false;

        _context.Presupuestos.Remove(presupuesto);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Presupuestos.AnyAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Presupuesto>> GetByClienteIdAsync(int clienteId)
    {
        return await _context.Presupuestos
            .Include(p => p.Cliente)
            .Include(p => p.Detalles)
            .Where(p => p.ClienteId == clienteId)
            .OrderByDescending(p => p.FechaCreacion)
            .ToListAsync();
    }
}
