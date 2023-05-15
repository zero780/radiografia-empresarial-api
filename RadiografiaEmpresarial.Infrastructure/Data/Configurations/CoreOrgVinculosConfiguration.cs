using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class CoreOrgVinculosConfiguration : IEntityTypeConfiguration<CoreOrgVinculos>
    {
        public void Configure(EntityTypeBuilder<CoreOrgVinculos> builder)
        {
            builder.ToTable("core__org_vinculos");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id__organizacion");

            builder.Property(e => e.IdVinculo).HasColumnName("id_vinculo");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CoreOrgVinculosCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("core__org_vinculos_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.CoreOrgVinculosDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("core__org_vinculos_deleted_by_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.CoreOrgVinculos)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__org_vinculos_id__organizacion_foreign");

            builder.HasOne(d => d.IdVinculoNavigation)
                .WithMany(p => p.CoreOrgVinculos)
                .HasForeignKey(d => d.IdVinculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__org_vinculos_id_vinculo_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CoreOrgVinculosUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("core__org_vinculos_updated_by_foreign");
        }
    }
}
