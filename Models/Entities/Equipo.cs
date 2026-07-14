using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("equipos")]
public class Equipo
{
    [Key]
    [Column("id_equipo")]
    public int IdEquipo { get; set; }

    [Column("id_tipo")]
    public int IdTipo { get; set; }

    [Required]
    [MaxLength(45)]
    [Column("marca")]
    public string Marca { get; set; } = string.Empty;

    [Required]
    [MaxLength(45)]
    [Column("modelo")]
    public string Modelo { get; set; } = string.Empty;

    [Required]
    [MaxLength(45)]
    [Column("serie")]
    public string Serie { get; set; } = string.Empty;

    [MaxLength(45)]
    [Column("mainboard")]
    public string? Mainboard { get; set; }

    [MaxLength(45)]
    [Column("procesador")]
    public string? Procesador { get; set; }

    [MaxLength(45)]
    [Column("memoria")]
    public string? Memoria { get; set; }

    [MaxLength(45)]
    [Column("disco_duro")]
    public string? DiscoDuro { get; set; }

    [MaxLength(45)]
    [Column("fuente")]
    public string? Fuente { get; set; }

    [MaxLength(45)]
    [Column("case_pc")]
    public string? CasePc { get; set; }

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    [ForeignKey(nameof(IdTipo))]
    public virtual Tipo? Tipo { get; set; }

    public virtual ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
}
