using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("usuarios_roles")]
public class UsuarioRol
{
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_rol")]
    public int IdRol { get; set; }

    [ForeignKey(nameof(IdUsuario))]
    public virtual Usuario Usuario { get; set; } = null!;

    [ForeignKey(nameof(IdRol))]
    public virtual Rol Rol { get; set; } = null!;
}
