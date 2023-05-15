using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class AuthTokenAppsConfiguration : IEntityTypeConfiguration<AuthTokenApps>
    {
        public void Configure(EntityTypeBuilder<AuthTokenApps> builder)
        {
            builder.ToTable("auth__token_apps");

            builder.HasIndex(e => e.Token)
                .HasName("auth__token_apps_token_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(255);

            builder.Property(e => e.Secret)
                .IsRequired()
                .HasColumnName("secret")
                .HasMaxLength(255);

            builder.Property(e => e.Slug)
                .IsRequired()
                .HasColumnName("slug")
                .HasMaxLength(255);

            builder.Property(e => e.Token)
                .IsRequired()
                .HasColumnName("token")
                .HasMaxLength(255);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");
        }
    }
}
