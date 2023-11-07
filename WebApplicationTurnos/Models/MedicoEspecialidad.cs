namespace WebApplicationTurnos.Models
{
    public class MedicoEspecialidad
    {
        public int IdMedico {  get; set; }
        public int IdEspecialidad { get; set; }
        public Medico MedicoNavigation { get; set; } = null!;
        public Especialidad EspecialidadNavigation { get; set; } = null!;
    }
}
