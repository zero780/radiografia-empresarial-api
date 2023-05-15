using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas3AConfiguration : IEntityTypeConfiguration<RadRespuestas3A>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas3A> builder)
        {
            builder.ToTable("rad__respuestas_3_a");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Factor)
                .IsRequired()
                .HasColumnName("factor");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdImportancia).HasColumnName("id_importancia");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdPosicionamiento).HasColumnName("id_posicionamiento");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas3A)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_3_a_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas3A)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_3_a_id_grupo_foreign");

            builder.HasOne(d => d.IdImportanciaNavigation)
                .WithMany(p => p.RadRespuestas3A)
                .HasForeignKey(d => d.IdImportancia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_3_a_id_importancia_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas3A)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_3_a_id_organizacion_foreign");

            builder.HasOne(d => d.IdPosicionamientoNavigation)
                .WithMany(p => p.RadRespuestas3A)
                .HasForeignKey(d => d.IdPosicionamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_3_a_id_posicionamiento_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas3A)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_3_a_id_radiografia_foreign");
        }
    }
}
