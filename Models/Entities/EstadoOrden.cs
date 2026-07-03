using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("estados_orden")]
public class EstadoOrden
{
    [Key]
    [Column("id_estado_orden")]
    public int IdEstadoOrden { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("estado_orden")]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(150)]
    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    public virtual ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
}
