using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class AuthRoUsuariosConfiguration : IEntityTypeConfiguration<AuthRoUsuarios>
    {
        public void Configure(EntityTypeBuilder<AuthRoUsuarios> builder)
        {
            builder.ToTable("auth__ro_usuarios");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasColumnName("created_by");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.IdRol).HasColumnName("id_rol");

            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            builder.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.AuthRoUsuariosCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("auth__ro_usuarios_created_by_foreign");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.AuthRoUsuariosDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("auth__ro_usuarios_deleted_by_foreign");

            builder.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.AuthRoUsuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth__ro_usuarios_id_rol_foreign");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.AuthRoUsuariosIdUsuarioNavigation)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth__ro_usuarios_id_usuario_foreign");

            builder.HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.AuthRoUsuariosUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("auth__ro_usuarios_updated_by_foreign");
        }
    }
}
