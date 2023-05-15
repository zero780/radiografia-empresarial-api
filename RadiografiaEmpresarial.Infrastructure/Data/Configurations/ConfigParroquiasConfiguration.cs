using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class ConfigParroquiasConfiguration : IEntityTypeConfiguration<ConfigParroquias>
    {
        public void Configure(EntityTypeBuilder<ConfigParroquias> builder)
        {
            builder.ToTable("config__parroquias");

            builder.HasIndex(e => e.Codigo)
                .HasName("config__parroquias_codigo_unique")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CodCanton)
                .IsRequired()
                .HasColumnName("cod_canton")
                .HasMaxLength(25);

            builder.Property(e => e.CodProvincia)
                .IsRequired()
                .HasColumnName("cod_provincia")
                .HasMaxLength(25);

            builder.Property(e => e.Codigo)
                .IsRequired()
                .HasColumnName("codigo")
                .HasMaxLength(25);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdCanton).HasColumnName("id_canton");

            builder.Property(e => e.IdProvincia).HasColumnName("id_provincia");

            builder.Property(e => e.IsRural)
                .IsRequired()
                .HasColumnName("is_rural")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(250);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdCantonNavigation)
                .WithMany(p => p.ConfigParroquias)
                .HasForeignKey(d => d.IdCanton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("config__parroquias_id_canton_foreign");

            builder.HasOne(d => d.IdProvinciaNavigation)
                .WithMany(p => p.ConfigParroquias)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("config__parroquias_id_provincia_foreign");
        }
    }
}
