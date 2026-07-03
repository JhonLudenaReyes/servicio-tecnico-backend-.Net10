using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("ciudades")]
public class Ciudad
{
    [Key]
    [Column("id_ciudad")]
    public int IdCiudad { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("ciudad")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
