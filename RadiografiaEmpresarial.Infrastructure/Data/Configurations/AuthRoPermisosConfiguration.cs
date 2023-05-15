using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class AuthRoPermisosConfiguration : IEntityTypeConfiguration<AuthRoPermisos>
    {
        public void Configure(EntityTypeBuilder<AuthRoPermisos> builder)
        {
            builder.ToTable("auth__ro_permisos");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdPermiso).HasColumnName("id_permiso");

            builder.Property(e => e.IdRol).HasColumnName("id_rol");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdPermisoNavigation)
                .WithMany(p => p.AuthRoPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth__ro_permisos_id_permiso_foreign");

            builder.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.AuthRoPermisos)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth__ro_permisos_id_rol_foreign");
        }
    }
}
