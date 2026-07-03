using Microsoft.EntityFrameworkCore;
using servicio_tecnico_backend.Models.Entities;

namespace servicio_tecnico_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tipo> Tipos { get; set; } = null!;
    public DbSet<Ciudad> Ciudades { get; set; } = null!;
    public DbSet<Equipo> Equipos { get; set; } = null!;
    public DbSet<Persona> Personas { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<EstadoOrden> EstadosOrden { get; set; } = null!;
    public DbSet<Orden> Ordenes { get; set; } = null!;
    public DbSet<Permiso> Permisos { get; set; } = null!;
    public DbSet<Rol> Roles { get; set; } = null!;
    public DbSet<RolPermiso> RolesPermisos { get; set; } = null!;
    public DbSet<UsuarioRol> UsuariosRoles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de llaves compuestas
        modelBuilder.Entity<RolPermiso>()
            .HasKey(rp => new { rp.IdRol, rp.IdPermiso });

        modelBuilder.Entity<UsuarioRol>()
            .HasKey(ur => new { ur.IdUsuario, ur.IdRol });

        // Evitar cascadas innecesarias si es necesario
        modelBuilder.Entity<Orden>()
            .HasOne(o => o.Persona)
            .WithMany(p => p.Ordenes)
            .HasForeignKey(o => o.IdPersona)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Orden>()
            .HasOne(o => o.Usuario)
            .WithMany(u => u.Ordenes)
            .HasForeignKey(o => o.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Orden>()
            .HasOne(o => o.Equipo)
            .WithMany(e => e.Ordenes)
            .HasForeignKey(o => o.IdEquipo)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Orden>()
            .HasOne(o => o.EstadoOrdenNavigation)
            .WithMany(e => e.Ordenes)
            .HasForeignKey(o => o.IdEstadoOrden)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
