using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas4A1Configuration : IEntityTypeConfiguration<RadRespuestas4A1>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas4A1> builder)
        {
            builder.ToTable("rad__respuestas_4_a1");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdFrecuenciaDespachos).HasColumnName("id_frecuencia_despachos");

            builder.Property(e => e.IdFrecuenciaRecepciones).HasColumnName("id_frecuencia_recepciones");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.TamDespachos)
                .HasColumnName("tam_despachos")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.TamRecepciones)
                .HasColumnName("tam_recepciones")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas4A1)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_a1_id_estado_foreign");

            builder.HasOne(d => d.IdFrecuenciaDespachosNavigation)
                .WithMany(p => p.RadRespuestas4A1IdFrecuenciaDespachosNavigation)
                .HasForeignKey(d => d.IdFrecuenciaDespachos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_a1_id_frecuencia_despachos_foreign");

            builder.HasOne(d => d.IdFrecuenciaRecepcionesNavigation)
                .WithMany(p => p.RadRespuestas4A1IdFrecuenciaRecepcionesNavigation)
                .HasForeignKey(d => d.IdFrecuenciaRecepciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_a1_id_frecuencia_recepciones_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas4A1)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_4_a1_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas4A1)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_a1_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas4A1)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_a1_id_radiografia_foreign");
        }

    }
}
