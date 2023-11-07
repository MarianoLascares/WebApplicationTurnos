using Microsoft.EntityFrameworkCore;

namespace WebApplicationTurnos.Models.Seeding
{
    public class SeedingInicialLogin
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Login Mariano = new Login()
            {
                Id = 1,
                Usuario = "mariano",
                Password = "BBAF85A574B5B26907872548398B034EDB8DD7D794CE74D4E4461EBFA6224581" //190115
            };

            modelBuilder.Entity<Login>().HasData(Mariano);
        }
    }
}
