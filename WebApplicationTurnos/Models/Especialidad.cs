using System.ComponentModel.DataAnnotations;

namespace WebApplicationTurnos.Models
{
    public class Especialidad
    {
        public int Id { get; set; }
        [StringLength(200, ErrorMessage = "Debe ingresar como máximo 200 caracteres")]
        [Required (ErrorMessage = "Debe ingresar ua descripción")]
        [Display (Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string Descripcion { get; set; } = null!;
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; } = new List<MedicoEspecialidad>();
    }
}
