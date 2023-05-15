using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class AuthRolesConfiguration : IEntityTypeConfiguration<AuthRoles>
    {
        public void Configure(EntityTypeBuilder<AuthRoles> builder)
        {
            builder.ToTable("auth__roles");

            builder.HasIndex(e => e.Slug)
                .HasName("auth__roles_slug_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

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
        }
    }
}
