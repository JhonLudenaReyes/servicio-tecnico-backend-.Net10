using servicio_tecnico_backend.Models.Entities;

namespace servicio_tecnico_backend.Services.Interfaces;

public interface IOrdenService : IGenericService<Orden>
{
    Task<IEnumerable<Orden>> GetByClienteAsync(int idPersona);
    Task<IEnumerable<Orden>> GetByEstadoAsync(int idEstado);
}
