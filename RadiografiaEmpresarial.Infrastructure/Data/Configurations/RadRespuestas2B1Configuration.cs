using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;


namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas2B1Configuration : IEntityTypeConfiguration<RadRespuestas2B1>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas2B1> builder)
        {
            builder.ToTable("rad__respuestas_2_b1");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdActividad).HasColumnName("id_actividad");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdProducto).HasColumnName("id_producto");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdActividadNavigation)
                .WithMany(p => p.RadRespuestas2B1)
                .HasForeignKey(d => d.IdActividad)
                .HasConstraintName("rad__respuestas_2_b1_id_actividad_foreign");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas2B1)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_b1_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas2B1)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_2_b1_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas2B1)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_b1_id_organizacion_foreign");

            builder.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.RadRespuestas2B1)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("rad__respuestas_2_b1_id_producto_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas2B1)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_b1_id_radiografia_foreign");
        }
    }
}
