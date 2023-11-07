using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplicationTurnos.Models.Seeding;

namespace WebApplicationTurnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones) : base(opciones)
        {
            
        }

        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingInicialEspecialidad.Seed(modelBuilder);
            SeedingInicialLogin.Seed(modelBuilder);
            SeedingInicialPacientes.Seed(modelBuilder);
            SeedingInicialMedico.Seed(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
    }
}
