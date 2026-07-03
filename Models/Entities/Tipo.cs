using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("tipos")]
public class Tipo
{
    [Key]
    [Column("id_tipo")]
    public int IdTipo { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("tipo")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
