using Microsoft.EntityFrameworkCore;

namespace WebApplicationTurnos.Models.Seeding
{
    public class SeedingInicialMedico
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Medico Mariano = new Medico()
            {
                Id = 1,
                Nombre = "Mariano",
                Apellido = "Lascares",
                Direccion = "San Juan 1349",
                Telefono = "3416676363",
                Email = "mariano.lascares@gmail.com",
                HorarioAtencionDesde = new DateTime(2023, 11, 3, 07, 00, 00),
                HorarioAtencionHasta = new DateTime(2023, 11, 3, 15, 00, 00),
            };

            Medico Orne = new Medico()
            {
                Id = 2,
                Nombre = "Ornela",
                Apellido = "Mansilla",
                Direccion = "San Juan 1349",
                Telefono = "3416423125",
                Email = "ornela.mansilla@gmail.com",
                HorarioAtencionDesde = new DateTime(2023, 11, 3, 09, 00, 00),
                HorarioAtencionHasta = new DateTime(2023, 11, 3, 16, 00, 00),
            };

            modelBuilder.Entity<Medico>().HasData(Mariano, Orne);

            MedicoEspecialidad MarianoCardio = new MedicoEspecialidad()
            {
                IdEspecialidad = 1,
                IdMedico = 1
            };

            MedicoEspecialidad OrnePediatra = new MedicoEspecialidad()
            {
                IdEspecialidad = 5,
                IdMedico = 2
            };

            modelBuilder.Entity<MedicoEspecialidad>().HasData(MarianoCardio, OrnePediatra);
        }
    }
}
