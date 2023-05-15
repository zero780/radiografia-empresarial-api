using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class CoreViRepresentanteConfiguration : IEntityTypeConfiguration<CoreViRepresentante>
    {
        public void Configure(EntityTypeBuilder<CoreViRepresentante> builder)
        {
            builder.ToTable("core__vi_representante");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.IdUsuario).HasColumnName("id__usuario");

            builder.Property(e => e.IdVinculo).HasColumnName("id_vinculo");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CoreViRepresentanteCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("core__vi_representante_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.CoreViRepresentanteDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("core__vi_representante_deleted_by_foreign");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.CoreViRepresentanteIdUsuarioNavigation)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__vi_representante_id__usuario_foreign");

            builder.HasOne(d => d.IdVinculoNavigation)
                .WithMany(p => p.CoreViRepresentante)
                .HasForeignKey(d => d.IdVinculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("core__vi_representante_id_vinculo_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CoreViRepresentanteUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("core__vi_representante_updated_by_foreign");
        }
    }
}
