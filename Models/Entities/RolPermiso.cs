using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("roles_permisos")]
public class RolPermiso
{
    [Column("id_rol")]
    public int IdRol { get; set; }

    [Column("id_permiso")]
    public int IdPermiso { get; set; }

    [ForeignKey(nameof(IdRol))]
    public virtual Rol Rol { get; set; } = null!;

    [ForeignKey(nameof(IdPermiso))]
    public virtual Permiso Permiso { get; set; } = null!;
}
