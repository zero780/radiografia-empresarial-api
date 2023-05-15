using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class CoreGrIntegrantesConfiguration : IEntityTypeConfiguration<CoreGrIntegrantes>
    {
        public void Configure(EntityTypeBuilder<CoreGrIntegrantes> builder)
        {
            builder.ToTable("core__gr_integrantes");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdTipo).HasColumnName("id_tipo");

            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CoreGrIntegrantesCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("core__gr_integrantes_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.CoreGrIntegrantesDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("core__gr_integrantes_deleted_by_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.CoreGrIntegrantes)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__gr_integrantes_id_grupo_foreign");

            builder.HasOne(d => d.IdTipoNavigation)
                .WithMany(p => p.CoreGrIntegrantes)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__gr_integrantes_id_tipo_foreign");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.CoreGrIntegrantesIdUsuarioNavigation)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__gr_integrantes_id_usuario_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CoreGrIntegrantesUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("core__gr_integrantes_updated_by_foreign");
        }
    }
}
