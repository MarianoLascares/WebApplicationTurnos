using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplicationTurnos.Models.Configuration
{
    public class PacientesConfiguration : IEntityTypeConfiguration<Pacientes>
    {
        public void Configure(EntityTypeBuilder<Pacientes> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(p => p.Apellido)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

            builder.Property(p => p.Direccion)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

            builder.Property(p => p.Telefono)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false);

            builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);
        }
    }
}
