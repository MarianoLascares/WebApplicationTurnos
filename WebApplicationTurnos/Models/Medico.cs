using System.ComponentModel.DataAnnotations;

namespace WebApplicationTurnos.Models
{
    public class Medico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        [Display (Prompt = "Ingrese un Nombre")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar un Apellido")]
        [Display(Prompt = "Ingrese un Apellido")]
        public string Apellido { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar una Dirección")]
        [Display(Name = "Dirección", Prompt = "Ingrese una Dirección")]
        public string Direccion { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar un Teléfono")]
        [Display(Name = "Teléfono", Prompt = "Ingrese un Teléfono")]
        public string Telefono { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar un Email")]
        [Display(Prompt = "Ingrese un Email")]
        [EmailAddress (ErrorMessage = "No es una dirección de email válida")]
        public string Email { get; set; } = null!;
        [Display(Name = "Horario de atención desde")]
        // con esto le damos formato de Horas, minutos y AM o Pm y le decimos que aplique este formato tanto en el modo display como edit
        [DisplayFormat (DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }
        [Display(Name = "Horario de atención hasta")]
        [DisplayFormat (DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; } = new List<MedicoEspecialidad>();
        public List<Turno> Turnos { get; set; } = new List<Turno>();
    }
}
