using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas2AConfiguration : IEntityTypeConfiguration<RadRespuestas2A>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas2A> builder)
        {
            builder.ToTable("rad__respuestas_2_a");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.EsMatriz)
                .IsRequired()
                .HasColumnName("es_matriz")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.FechaConstitucion)
                .HasColumnName("fecha_constitucion")
                .HasColumnType("datetime");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.IdTipologia).HasColumnName("id_tipologia");

            builder.Property(e => e.NEstablecimientos).HasColumnName("n_establecimientos");

            builder.Property(e => e.NTrabajadores).HasColumnName("n_trabajadores");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas2A)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_a_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas2A)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_2_a_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas2A)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_a_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas2A)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_a_id_radiografia_foreign");

            builder.HasOne(d => d.IdTipologiaNavigation)
                .WithMany(p => p.RadRespuestas2A)
                .HasForeignKey(d => d.IdTipologia)
                .HasConstraintName("rad__respuestas_2_a_id_tipologia_foreign");
        }
    }
}
