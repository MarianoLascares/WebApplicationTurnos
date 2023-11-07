using System.ComponentModel.DataAnnotations;

namespace WebApplicationTurnos.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Debe ingresar un Usuario")]
        public string Usuario { get; set; } = null!;
        [Required(ErrorMessage = "Debe ingresar una Contraseña")]
        public string Password { get; set; } = null!;
    }
}
