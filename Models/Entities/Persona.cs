using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("personas")]
public class Persona
{
    [Key]
    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("id_ciudad")]
    public int IdCiudad { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("nombres")]
    public string Nombres { get; set; } = string.Empty;

    [Required]
    [MaxLength(45)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    [Column("cedula")]
    public string Cedula { get; set; } = string.Empty;

    [MaxLength(13)]
    [Column("ruc")]
    public string? Ruc { get; set; }

    [MaxLength(150)]
    [Column("direccion")]
    public string? Direccion { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("celular")]
    public string Celular { get; set; } = string.Empty;

    [MaxLength(45)]
    [Column("email")]
    public string? Email { get; set; }

    [MaxLength(10)]
    [Column("telefono")]
    public string? Telefono { get; set; }

    [MaxLength(10)]
    [Column("telefono_adicional")]
    public string? TelefonoAdicional { get; set; }

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    [ForeignKey(nameof(IdCiudad))]
    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public virtual ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
}
