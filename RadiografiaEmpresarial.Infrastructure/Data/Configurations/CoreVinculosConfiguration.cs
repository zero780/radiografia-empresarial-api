using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class CoreVinculosConfiguration : IEntityTypeConfiguration<CoreVinculos>
    {
        public void Configure(EntityTypeBuilder<CoreVinculos> builder)
        {
            builder.ToTable("core__vinculos");

            builder.HasIndex(e => e.Slug)
                .HasName("core__vinculos_slug_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(255);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(150);

            builder.Property(e => e.Slug)
                .IsRequired()
                .HasColumnName("slug")
                .HasMaxLength(50);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CoreVinculosCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("core__vinculos_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.CoreVinculosDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("core__vinculos_deleted_by_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CoreVinculosUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("core__vinculos_updated_by_foreign");
        }
    }
}
