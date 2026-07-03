using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("permisos")]
public class Permiso
{
    [Key]
    [Column("id_permiso")]
    public int IdPermiso { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("permiso")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
}
