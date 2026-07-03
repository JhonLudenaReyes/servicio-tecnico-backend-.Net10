using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio_tecnico_backend.Models.Entities;

[Table("ordenes")]
public class Orden
{
    [Key]
    [Column("id_orden")]
    public int IdOrden { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_equipo")]
    public int IdEquipo { get; set; }

    [Column("id_estado_orden")]
    public int IdEstadoOrden { get; set; }

    [Required]
    [Column("fecha_recepcion")]
    public DateTime FechaRecepcion { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("posible_problema")]
    public string PosibleProblema { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    [Column("trabajo_realizar")]
    public string TrabajoRealizar { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    [Column("observaciones")]
    public string Observaciones { get; set; } = string.Empty;

    [MaxLength(150)]
    [Column("condicion_fisica_ingreso")]
    public string? CondicionFisicaIngreso { get; set; }

    [Column("fecha_reparacion")]
    public DateTime? FechaReparacion { get; set; }

    [Column("fecha_aproximada")]
    public DateTime? FechaAproximada { get; set; }

    [Column("fecha_entrega")]
    public DateTime? FechaEntrega { get; set; }

    [Column("reporte_tecnico")]
    public string? ReporteTecnico { get; set; }

    [Required]
    [MaxLength(1)]
    [Column("estado")]
    public string Estado { get; set; } = "A";

    [ForeignKey(nameof(IdPersona))]
    public virtual Persona Persona { get; set; } = null!;

    [ForeignKey(nameof(IdUsuario))]
    public virtual Usuario Usuario { get; set; } = null!;

    [ForeignKey(nameof(IdEquipo))]
    public virtual Equipo Equipo { get; set; } = null!;

    [ForeignKey(nameof(IdEstadoOrden))]
    public virtual EstadoOrden EstadoOrdenNavigation { get; set; } = null!;
}
