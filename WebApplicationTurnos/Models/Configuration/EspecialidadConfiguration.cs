using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplicationTurnos.Models.Configuration
{
    public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }
}
