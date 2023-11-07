using System.ComponentModel.DataAnnotations;

namespace WebApplicationTurnos.Models
{
    public class Pacientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        [Display(Prompt = "Ingrese un Nombre")]
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
        [EmailAddress(ErrorMessage = "No es una dirección de email válida")]
        public string Email { get; set; } = null!;
        public List<Turno> Turnos { get; set; } = new List<Turno>();
    }
}
