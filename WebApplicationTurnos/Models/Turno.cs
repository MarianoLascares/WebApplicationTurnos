using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTurnos.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        [Display (Name = "Fecha y hora de inicio del turno")]
        public DateTime FechaHoraInicio { get; set; }
        [Display(Name = "Fecha y hora de fin del turno")]
        public DateTime FechaHoraFin {  get; set; }
        public Pacientes PacientesNavigation { get; set; } = null!;
        public Medico MedicoNavigation { get; set; } = null!;
    }
}
