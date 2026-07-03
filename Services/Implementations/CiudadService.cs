using Microsoft.EntityFrameworkCore;
using servicio_tecnico_backend.Data;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Services.Implementations;

public class CiudadService : GenericService<Ciudad>, ICiudadService
{
    public CiudadService(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades.Where(c => c.Estado.Equals("A")).ToListAsync();
    }
}
