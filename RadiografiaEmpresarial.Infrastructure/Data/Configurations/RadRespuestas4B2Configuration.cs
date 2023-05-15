using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas4B2Configuration : IEntityTypeConfiguration<RadRespuestas4B2>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas4B2> builder)
        {
            builder.ToTable("rad__respuestas_4_b2");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnName("descripcion");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.Problema)
                .IsRequired()
                .HasColumnName("problema");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas4B2)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_b2_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas4B2)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_4_b2_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas4B2)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_b2_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas4B2)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_b2_id_radiografia_foreign");
        }
    }
}
