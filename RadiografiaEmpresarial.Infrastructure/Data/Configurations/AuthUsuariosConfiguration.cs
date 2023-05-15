using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class AuthUsuariosConfiguration : IEntityTypeConfiguration<AuthUsuarios>
    {
        public void Configure(EntityTypeBuilder<AuthUsuarios> builder)
        {
            builder.ToTable("auth__usuarios");

            builder.HasIndex(e => e.Email)
                .HasName("auth__usuarios_email_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(255);

            builder.Property(e => e.Extra).HasColumnName("extra");

            builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(500);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.DeletedByNavigation)
                .WithMany(p => p.InverseDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("auth__usuarios_deleted_by_foreign");
        }
    }
}
