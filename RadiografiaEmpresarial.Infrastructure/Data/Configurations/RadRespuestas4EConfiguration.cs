using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas4EConfiguration : IEntityTypeConfiguration<RadRespuestas4E>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas4E> builder)
        {
            builder.ToTable("rad__respuestas_4_e");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.CostoEliminacion).HasColumnName("costo_eliminacion");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.Medida)
                .HasColumnName("medida")
                .HasMaxLength(25);

            builder.Property(e => e.ResiduoGenerado)
                .IsRequired()
                .HasColumnName("residuo_generado")
                .HasMaxLength(500);

            builder.Property(e => e.Tratamiento)
                .HasColumnName("tratamiento")
                .HasMaxLength(500);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas4E)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_e_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas4E)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_4_e_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas4E)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_e_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas4E)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_4_e_id_radiografia_foreign");
        }
    }
}
