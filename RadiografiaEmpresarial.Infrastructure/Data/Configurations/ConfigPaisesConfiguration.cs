using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class ConfigPaisesConfiguration : IEntityTypeConfiguration<ConfigPaises>
    {
        public void Configure(EntityTypeBuilder<ConfigPaises> builder)
        {
            builder.ToTable("config__paises");

            builder.HasIndex(e => e.Codigo)
                .HasName("config__paises_codigo_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasColumnName("codigo")
                .HasMaxLength(25);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdContinente).HasColumnName("id_continente");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(250);

            builder.Property(e => e.Orden)
                .HasColumnName("orden")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdContinenteNavigation)
                .WithMany(p => p.ConfigPaises)
                .HasForeignKey(d => d.IdContinente)
                .HasConstraintName("config__paises_id_continente_foreign");
        }
    }
}
