using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("usuarios")]
public class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("usuario")]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("contrasenia")]
    public string Contrasenia { get; set; } = string.Empty;

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    [ForeignKey(nameof(IdPersona))]
    public virtual Persona Persona { get; set; } = null!;

    public virtual ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
    public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
}
