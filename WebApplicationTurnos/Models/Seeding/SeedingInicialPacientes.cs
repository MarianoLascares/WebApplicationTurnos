using Microsoft.EntityFrameworkCore;

namespace WebApplicationTurnos.Models.Seeding
{
    public class SeedingInicialPacientes
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Pacientes Emma = new Pacientes()
            {
                Id = 1,
                Nombre = "Emma",
                Apellido = "Lascares",
                Direccion = "San Juan 1349",
                Telefono = "3416741852",
                Email = "emma.lascares@gmail.com"
            };

            Pacientes Ian = new Pacientes()
            {
                Id = 2,
                Nombre = "Ian",
                Apellido = "Lascares",
                Direccion = "San Juan 1349",
                Telefono = "3416444235",
                Email = "ian.lascares@gmail.com"
            };

            modelBuilder.Entity<Pacientes>().HasData(Emma, Ian);
        }
    }
}
