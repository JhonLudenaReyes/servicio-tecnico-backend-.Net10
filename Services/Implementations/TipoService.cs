using Microsoft.EntityFrameworkCore;
using servicio_tecnico_backend.Data;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Services.Implementations;

public class TipoService : GenericService<Tipo>, ITipoService
{
    public TipoService(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Tipo>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public override async Task<Tipo?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    // Hereda CreateAsync, UpdateAsync, DeleteAsync del GenericService
}
