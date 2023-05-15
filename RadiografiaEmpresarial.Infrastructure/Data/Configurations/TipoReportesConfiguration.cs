using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    class TipoReportesConfiguration : IEntityTypeConfiguration<TipoReportes>
    {
        public void Configure(EntityTypeBuilder<TipoReportes> builder)
        {
            builder.ToTable("tipo__reportes");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Columnas).HasColumnName("columnas");

            builder.Property(e => e.Componente)
                .IsRequired()
                .HasColumnName("componente")
                .HasMaxLength(255);

            builder.Property(e => e.Consulta).HasColumnName("consulta");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("nombre")
                .HasMaxLength(255);

            builder.Property(e => e.NombreArchivo)
                .IsRequired()
                .HasColumnName("nombre_archivo")
                .HasMaxLength(255);

            builder.Property(e => e.Orden)
                .HasColumnName("orden")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.Slug)
                .IsRequired()
                .HasColumnName("slug")
                .HasMaxLength(255);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Url)
                .IsRequired()
                .HasColumnName("url");
        }
    }
}
