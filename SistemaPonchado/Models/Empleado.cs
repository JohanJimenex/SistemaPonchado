using System.ComponentModel.DataAnnotations;

namespace SistemaPonchado.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string Cedula { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string? Departamento { get; set; }
        
        [StringLength(50)]
        public string? Cargo { get; set; }
        
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        
        public bool Activo { get; set; } = true;
        
        // Relación con usuario
        public virtual Usuario? Usuario { get; set; }
        
        // Relación con ponchados
        public virtual ICollection<Ponchado> Ponchados { get; set; } = new List<Ponchado>();
    }
}