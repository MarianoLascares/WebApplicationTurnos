using Microsoft.EntityFrameworkCore;

namespace WebApplicationTurnos.Models.Seeding
{
    public class SeedingInicialEspecialidad
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Especialidad Cardiologo = new Especialidad()
            {
                Id = 1,
                Descripcion = "Cariólogo"
            };

            Especialidad Odontologo = new Especialidad()
            {
                Id = 2,
                Descripcion = "Odontólogo"
            };

            Especialidad Traumatologo = new Especialidad()
            {
                Id = 3,
                Descripcion = "Traumatólogo"
            };

            Especialidad Oftalmologo = new Especialidad()
            {
                Id = 4,
                Descripcion = "Oftalmólogo"
            };

            Especialidad Pediatra = new Especialidad()
            {
                Id = 5,
                Descripcion = "Pediatra"
            };

            modelBuilder.Entity<Especialidad>().HasData(Cardiologo, Odontologo, Traumatologo,
                Oftalmologo, Pediatra);
        }
    }
}
