using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class AuthTokenUsuariosConfiguration : IEntityTypeConfiguration<AuthTokenUsuarios>
    {
        public void Configure(EntityTypeBuilder<AuthTokenUsuarios> builder)
        {
            builder.ToTable("auth__token_usuarios");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            builder.Property(e => e.Token)
                .IsRequired()
                .HasColumnName("token")
                .HasMaxLength(1000);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.AuthTokenUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth__token_usuarios_id_usuario_foreign");
        }
    }
}
