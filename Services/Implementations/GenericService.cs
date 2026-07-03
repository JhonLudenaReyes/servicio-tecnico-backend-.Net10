using Microsoft.EntityFrameworkCore;
using servicio_tecnico_backend.Data;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Services.Implementations;

public class GenericService<TEntity> : IGenericService<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericService(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> UpdateAsync(int id, TEntity entity)
    {
        var existingEntity = await _dbSet.FindAsync(id);
        if (existingEntity == null) return false;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        _dbSet.Update(existingEntity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        // Soft delete si "Estado" property existe
        var property = typeof(TEntity).GetProperty("Estado");
        if (property != null && property.PropertyType == typeof(string))
        {
            property.SetValue(entity, "I");
            _dbSet.Update(entity);
        }
        else
        {
            _dbSet.Remove(entity);
        }

        return await _context.SaveChangesAsync() > 0;
    }
}
