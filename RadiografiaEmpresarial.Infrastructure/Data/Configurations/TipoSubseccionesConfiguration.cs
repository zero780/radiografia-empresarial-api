using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class TipoSubseccionesConfiguration : IEntityTypeConfiguration<TipoSubsecciones>
    {
        public void Configure(EntityTypeBuilder<TipoSubsecciones> builder)
        {
            builder.ToTable("tipo_subsecciones");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Descripcion).HasColumnName("descripcion");

            builder.Property(e => e.IdSeccion).HasColumnName("id_seccion");

            builder.Property(e => e.IdTipoRespuesta).HasColumnName("id_tipo_respuesta");

            builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(255);

            builder.Property(e => e.Orden)
                .HasColumnName("orden")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Url)
                .IsRequired()
                .HasColumnName("url");

            builder.HasOne(d => d.IdSeccionNavigation)
                .WithMany(p => p.TipoSubsecciones)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_subsecciones_id_seccion_foreign");

            builder.HasOne(d => d.IdTipoRespuestaNavigation)
                .WithMany(p => p.TipoSubsecciones)
                .HasForeignKey(d => d.IdTipoRespuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_subsecciones_id_tipo_respuesta_foreign");
        }
    }
}
