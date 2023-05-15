using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas4CConfiguration : IEntityTypeConfiguration<RadRespuestas4C>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas4C> builder)
        {
            builder.ToTable("rad__respuestas_4_c");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CostoTratamiento).HasColumnName("costo_tratamiento");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.HorasParadas).HasColumnName("horas_paradas");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.IdSuministroAgua).HasColumnName("id_suministro_agua");

            builder.Property(e => e.Necesidad).HasColumnName("necesidad");

            builder.Property(e => e.NecesidadTratamiento).HasColumnName("necesidad_tratamiento");

            builder.Property(e => e.TipoTratamiento).HasColumnName("tipo_tratamiento");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas4C)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_c_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas4C)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_4_c_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas4C)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_c_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas4C)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_c_id_radiografia_foreign");

            builder.HasOne(d => d.IdSuministroAguaNavigation)
                .WithMany(p => p.RadRespuestas4C)
                .HasForeignKey(d => d.IdSuministroAgua)
                .HasConstraintName("rad__respuestas_4_c_id_suministro_agua_foreign");
        }
    }
}
