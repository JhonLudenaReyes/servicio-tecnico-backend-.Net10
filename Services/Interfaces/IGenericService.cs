namespace servicio_tecnico_backend.Services.Interfaces;

public interface IGenericService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<bool> UpdateAsync(int id, TEntity entity);
    Task<bool> DeleteAsync(int id);
}
