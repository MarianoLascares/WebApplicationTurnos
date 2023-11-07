using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplicationTurnos.Models.Configuration
{
    public class MedicoEspecialidadConfiguration : IEntityTypeConfiguration<MedicoEspecialidad>
    {
        public void Configure(EntityTypeBuilder<MedicoEspecialidad> builder)
        {
            builder.HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            builder.HasOne(x => x.MedicoNavigation)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdMedico);

            builder.HasOne(x => x.EspecialidadNavigation)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdEspecialidad);
        }
    }
}
