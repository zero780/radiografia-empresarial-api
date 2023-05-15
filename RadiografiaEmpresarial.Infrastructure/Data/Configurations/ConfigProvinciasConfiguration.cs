using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class ConfigProvinciasConfiguration : IEntityTypeConfiguration<ConfigProvincias>
    {
        public void Configure(EntityTypeBuilder<ConfigProvincias> builder)
        {
            builder.ToTable("config__provincias");

            builder.HasIndex(e => e.Codigo)
                .HasName("config__provincias_codigo_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasColumnName("codigo")
                .HasMaxLength(25);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdPais).HasColumnName("id_pais");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(250);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdPaisNavigation)
                .WithMany(p => p.ConfigProvincias)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("config__provincias_id_pais_foreign");
        }
    }
}
