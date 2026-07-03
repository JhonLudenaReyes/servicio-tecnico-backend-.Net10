
using Microsoft.EntityFrameworkCore;
using servicio_tecnico_backend.Data;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Services.Implementations;

public class OrdenService : GenericService<Orden>, IOrdenService
{
    public OrdenService(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Orden>> GetAllAsync()
    {
        return await _context.Ordenes
            .Include(o => o.Persona)
            .Include(o => o.Usuario).ThenInclude(u => u.Persona)
            .Include(o => o.Equipo).ThenInclude(e => e.Tipo)
            .Include(o => o.EstadoOrdenNavigation)
            .Where(o => o.Estado == "A")
            .ToListAsync();
    }

    public override async Task<Orden?> GetByIdAsync(int id)
    {
        return await _context.Ordenes
            .Include(o => o.Persona)
            .Include(o => o.Usuario).ThenInclude(u => u.Persona)
            .Include(o => o.Equipo).ThenInclude(e => e.Tipo)
            .Include(o => o.EstadoOrdenNavigation)
            .FirstOrDefaultAsync(o => o.IdOrden == id);
    }

    public async Task<IEnumerable<Orden>> GetByClienteAsync(int idPersona)
    {
        return await _context.Ordenes
            .Include(o => o.Persona)
            .Include(o => o.Usuario).ThenInclude(u => u.Persona)
            .Include(o => o.Equipo).ThenInclude(e => e.Tipo)
            .Include(o => o.EstadoOrdenNavigation)
            .Where(o => o.IdPersona == idPersona && o.Estado == "A")
            .ToListAsync();
    }

    public async Task<IEnumerable<Orden>> GetByEstadoAsync(int idEstado)
    {
        return await _context.Ordenes
            .Include(o => o.Persona)
            .Include(o => o.Usuario).ThenInclude(u => u.Persona)
            .Include(o => o.Equipo).ThenInclude(e => e.Tipo)
            .Include(o => o.EstadoOrdenNavigation)
            .Where(o => o.IdEstadoOrden == idEstado && o.Estado == "A")
            .ToListAsync();
    }
}
