using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("roles")]
public class Rol
{
    [Key]
    [Column("id_rol")]
    public int IdRol { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("rol")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
    public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
}
