using System.ComponentModel.DataAnnotations;

namespace SistemaPonchado.Models
{
    public class Ponchado
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int EmpleadoId { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }
        
        public DateTime? HoraEntrada { get; set; }
        
        public DateTime? HoraSalida { get; set; }
        
        [StringLength(200)]
        public string? Observaciones { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        // Relación con empleado
        public virtual Empleado Empleado { get; set; } = null!;
        
        // Propiedades calculadas
        public TimeSpan? TiempoTrabajado
        {
            get
            {
                if (HoraEntrada.HasValue && HoraSalida.HasValue)
                {
                    return HoraSalida.Value - HoraEntrada.Value;
                }
                return null;
            }
        }
        
        public bool PoncheoCompleto => HoraEntrada.HasValue && HoraSalida.HasValue;
    }
}