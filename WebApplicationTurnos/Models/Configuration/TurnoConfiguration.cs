using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplicationTurnos.Models.Configuration
{
    public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.HasKey(x => new { x.IdTurno });

            builder.HasOne(x => x.MedicoNavigation)
            .WithMany(p => p.Turnos)
            .HasForeignKey(p => p.IdMedico);

            builder.HasOne(x => x.PacientesNavigation)
            .WithMany(p => p.Turnos)
            .HasForeignKey(p => p.IdPaciente);

            builder.Property(m => m.IdPaciente)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(m => m.IdMedico)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(m => m.FechaHoraInicio)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(m => m.FechaHoraFin)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
