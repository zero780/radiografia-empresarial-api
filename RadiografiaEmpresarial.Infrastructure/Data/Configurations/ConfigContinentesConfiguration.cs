using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class ConfigContinentesConfiguration : IEntityTypeConfiguration<ConfigContinentes>
    {
        public void Configure(EntityTypeBuilder<ConfigContinentes> builder)
        {
            builder.ToTable("config__continentes");

            builder.HasIndex(e => e.Codigo)
                .HasName("config__continentes_codigo_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasColumnName("codigo")
                .HasMaxLength(25);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

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
        }
    }
}
