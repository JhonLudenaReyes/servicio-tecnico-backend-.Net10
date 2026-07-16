using Microsoft.EntityFrameworkCore;
using servicio_tecnico_backend.Data;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Services.Implementations
{
    public class EquipoService : GenericService<Equipo>, IEquipoService
    {
        public EquipoService(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Equipo>> GetAllAsync()
        {
            return await _context.Equipos.Include(e => e.Tipo).Where(e => e.Estado.Equals("A")).ToListAsync();
        }   

    }
}
