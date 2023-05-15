using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class TipoCiiusConfiguration : IEntityTypeConfiguration<TipoCiius>
    {
        public void Configure(EntityTypeBuilder<TipoCiius> builder)
        {
            builder.ToTable("tipo__ciius");

            builder.HasIndex(e => e.Codigo)
                .HasName("tipo__ciius_codigo_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasColumnName("codigo")
                .HasMaxLength(50);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnName("descripcion");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Version)
                .IsRequired()
                .HasColumnName("version")
                .HasMaxLength(150);
        }
    }
}
