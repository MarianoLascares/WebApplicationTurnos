using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplicationTurnos.Models.Configuration
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(m => m.Apellido)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

            builder.Property(m => m.Direccion)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

            builder.Property(m => m.Telefono)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false);

            builder.Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

            builder.Property(m => m.HorarioAtencionDesde)
            .IsRequired()
            .IsUnicode(false)
            .HasConversion(
            v => v.TimeOfDay,   // Convierte el valor DateTime a TimeSpan (hora)
            v => DateTime.MinValue.Add(v)); // Convierte el valor TimeSpan a DateTime (añadiendo una fecha ficticia)

            builder.Property(m => m.HorarioAtencionHasta)
            .IsRequired()
            .IsUnicode(false).HasConversion(
            v => v.TimeOfDay,
            v => DateTime.MinValue.Add(v));
        }
    }
}
