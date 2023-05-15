using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRadiografiasConfiguration : IEntityTypeConfiguration<RadRadiografias>
    {
        public void Configure(EntityTypeBuilder<RadRadiografias> builder)
        {
            builder.ToTable("rad__radiografias");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.RadRadiografiasCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("rad__radiografias_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.RadRadiografiasDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("rad__radiografias_deleted_by_foreign");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRadiografias)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("rad__radiografias_id_estado_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRadiografias)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__radiografias_id_organizacion_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.RadRadiografiasUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("rad__radiografias_updated_by_foreign");
        }
    }
}
