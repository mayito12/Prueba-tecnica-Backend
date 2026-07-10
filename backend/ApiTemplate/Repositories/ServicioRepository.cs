using Microsoft.EntityFrameworkCore;
using ApiTemplate.Data;
using ApiTemplate.Models;

namespace ApiTemplate.Repositories;

public class ServicioRepository : IServicioRepository
{
    private readonly AppDbContext _context;

    public ServicioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Servicio>> GetAllAsync()
    {
        return await _context.Servicios.OrderBy(s => s.Nombre).ToListAsync();
    }

    public async Task<Servicio?> GetByIdAsync(int id)
    {
        return await _context.Servicios.FindAsync(id);
    }

    public async Task<Servicio> AddAsync(Servicio servicio)
    {
        _context.Servicios.Add(servicio);
        await _context.SaveChangesAsync();
        return servicio;
    }

    public async Task<Servicio> UpdateAsync(Servicio servicio)
    {
        _context.Entry(servicio).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return servicio;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);
        if (servicio == null) return false;

        _context.Servicios.Remove(servicio);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Servicios.AnyAsync(s => s.Id == id);
    }
}
