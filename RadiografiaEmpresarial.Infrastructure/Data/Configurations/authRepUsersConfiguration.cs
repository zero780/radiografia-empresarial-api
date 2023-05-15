using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class authRepUsersConfiguration : IEntityTypeConfiguration<AuthRepUsers>
    {
        public void Configure(EntityTypeBuilder<AuthRepUsers> builder)
        {
            builder.ToTable("auth__rep_users");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.IdReporte).HasColumnName("id_reporte");

            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.AuthRepUsersCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("auth__rep_users_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.AuthRepUsersDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("auth__rep_users_deleted_by_foreign");

            builder.HasOne(d => d.IdReporteNavigation)
                .WithMany(p => p.AuthRepUsers)
                .HasForeignKey(d => d.IdReporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth__rep_users_id_reporte_foreign");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.AuthRepUsersIdUsuarioNavigation)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth__rep_users_id_usuario_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.AuthRepUsersUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("auth__rep_users_updated_by_foreign");
        }
    }
}
