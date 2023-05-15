using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;


namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class CoreGruposConfiguration : IEntityTypeConfiguration<CoreGrupos>
    {
        public void Configure(EntityTypeBuilder<CoreGrupos> builder)
        {
            builder.ToTable("core__grupos");

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

            builder.Property(e => e.IdSupervisador).HasColumnName("id_supervisador");

            builder.Property(e => e.IdVinculo).HasColumnName("id_vinculo");

            builder.Property(e => e.MotivoRespuesta).HasColumnName("motivo_respuesta");

            builder.Property(e => e.MotivoSolicitud).HasColumnName("motivo_solicitud");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CoreGruposCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("core__grupos_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.CoreGruposDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("core__grupos_deleted_by_foreign");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.CoreGrupos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__grupos_id_estado_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.CoreGrupos)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__grupos_id_organizacion_foreign");

            builder.HasOne(d => d.IdSupervisadorNavigation)
                .WithMany(p => p.CoreGruposIdSupervisadorNavigation)
                .HasForeignKey(d => d.IdSupervisador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__grupos_id_supervisador_foreign");

            builder.HasOne(d => d.IdVinculoNavigation)
                .WithMany(p => p.CoreGrupos)
                .HasForeignKey(d => d.IdVinculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__grupos_id_vinculo_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CoreGruposUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("core__grupos_updated_by_foreign");
        }
    }
}
