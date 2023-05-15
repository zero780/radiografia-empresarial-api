using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class CoreOrganizacionesConfiguration : IEntityTypeConfiguration<CoreOrganizaciones>
    {
        public void Configure(EntityTypeBuilder<CoreOrganizaciones> builder)
        {
            builder.ToTable("core__organizaciones");

            builder.HasIndex(e => e.Identificacion)
                .HasName("core__organizaciones_identificacion_unique")
                .IsUnique();

            builder.HasIndex(e => e.Slug)
                .HasName("core__organizaciones_slug_unique")
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

            builder.Property(e => e.IdTipoIdentificacion).HasColumnName("id_tipo_identificacion");

            builder.Property(e => e.Identificacion)
                .IsRequired()
                .HasColumnName("identificacion")
                .HasMaxLength(50);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre");

            builder.Property(e => e.Slug)
                .IsRequired()
                .HasColumnName("slug")
                .HasMaxLength(50);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CoreOrganizacionesCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("core__organizaciones_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.CoreOrganizacionesDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("core__organizaciones_deleted_by_foreign");

            builder.HasOne(d => d.IdTipoIdentificacionNavigation)
                .WithMany(p => p.CoreOrganizaciones)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__organizaciones_id_tipo_identificacion_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CoreOrganizacionesUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("core__organizaciones_updated_by_foreign");
        }
    }
}
