// 👤 MODELO USUARIO
// Esta clase representa un usuario del sistema (Admin o Empleado)

using System.ComponentModel.DataAnnotations;

namespace SistemaPonchado.Models
{
    // 📝 CONCEPTO: Esta es una "entidad" o "modelo"
    // Representa los datos de un usuario en la base de datos
    public class Usuario
    {
        // 🔑 PRIMARY KEY: Identificador único del usuario
        [Key] // Entity Framework usa esto como clave primaria
        public int Id { get; set; }
        
        // 👨‍💻 NOMBRE DE USUARIO: Para hacer login
        [Required] // Campo obligatorio (no puede estar vacío)
        [StringLength(50)] // Máximo 50 caracteres
        public string NombreUsuario { get; set; } = string.Empty;
        
        // 🔒 CONTRASEÑA: Almacenada encriptada con BCrypt
        [Required] 
        [StringLength(255)] // Las contraseñas encriptadas necesitan más espacio
        public string Password { get; set; } = string.Empty;
        
        // 🎭 ROL: Define qué puede hacer el usuario
        [Required]
        [StringLength(20)]
        public string Rol { get; set; } = string.Empty; // "Admin" o "Empleado"
        
        // 🔄 CAMBIO DE CONTRASEÑA: Primera vez que inicia sesión
        public bool RequiereCambioPassword { get; set; } = true;
        
        // 📅 FECHA DE CREACIÓN: Cuándo se creó este usuario
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        // ✅ ESTADO: Si el usuario está activo o deshabilitado
        public bool Activo { get; set; } = true;
        
        // 🔗 RELACIÓN CON EMPLEADO
        // Si es un empleado, este campo conecta con los datos del empleado
        public int? EmpleadoId { get; set; } // "?" significa que puede ser null (para admin)
        
        // 💡 NAVIGATION PROPERTY: Entity Framework usa esto para cargar datos relacionados
        public virtual Empleado? Empleado { get; set; }
        
        // 🎯 CONCEPTOS CLAVE AQUÍ:
        // - Data Annotations ([Required], [Key], etc.)
        // - Relaciones entre tablas (Usuario → Empleado)
        // - Nullable types (int?, Empleado?)
        // - Virtual properties para lazy loading
    }
}