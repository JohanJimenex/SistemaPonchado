using Microsoft.EntityFrameworkCore;
using SistemaPonchado.Models;

namespace SistemaPonchado.Data
{
    public class SistemaPonchadoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Ponchado> Ponchados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sistemaPonchado.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Empleado)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Usuario>(u => u.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ponchado>()
                .HasOne(p => p.Empleado)
                .WithMany(e => e.Ponchados)
                .HasForeignKey(p => p.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices únicos
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Cedula)
                .IsUnique();

            // Configurar precisión de decimales para fechas/horas
            modelBuilder.Entity<Ponchado>()
                .Property(p => p.Fecha)
                .HasColumnType("DATE");

            // Datos iniciales - Usuario Admin
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    NombreUsuario = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"), // Contraseña hasheada
                    Rol = "Admin",
                    RequiereCambioPassword = false,
                    FechaCreacion = DateTime.Now,
                    Activo = true,
                    EmpleadoId = null
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}