using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class ConfigCantonesConfiguration : IEntityTypeConfiguration<ConfigCantones>
    {
        public void Configure(EntityTypeBuilder<ConfigCantones> builder)
        {
            builder.ToTable("config__cantones");

            builder.HasIndex(e => e.Codigo)
                .HasName("config__cantones_codigo_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CodProvincia)
                .IsRequired()
                .HasColumnName("cod_provincia")
                .HasMaxLength(25);

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasColumnName("codigo")
                .HasMaxLength(25);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdProvincia).HasColumnName("id_provincia");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(250);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdProvinciaNavigation)
                .WithMany(p => p.ConfigCantones)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("config__cantones_id_provincia_foreign");
        }
    }
}
