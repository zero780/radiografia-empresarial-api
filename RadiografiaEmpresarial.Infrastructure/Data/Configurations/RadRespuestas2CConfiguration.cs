using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas2CConfiguration : IEntityTypeConfiguration<RadRespuestas2C>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas2C> builder)
        {
            builder.ToTable("rad__respuestas_2_c");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.EsPBajoPlano)
                .IsRequired()
                .HasColumnName("es_p_bajo_plano")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.EsPDisenoPropio)
                .IsRequired()
                .HasColumnName("es_p_diseno_propio")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.EsPSubcontratado)
                .IsRequired()
                .HasColumnName("es_p_subcontratado")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.EsSPropio)
                .IsRequired()
                .HasColumnName("es_s_propio")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.EsSSubcontratado)
                .IsRequired()
                .HasColumnName("es_s_subcontratado")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.Facturacion)
                .HasColumnName("facturacion")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.Producto)
                .IsRequired()
                .HasColumnName("producto")
                .HasMaxLength(255);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas2C)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_c_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas2C)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_2_c_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas2C)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_c_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas2C)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_c_id_radiografia_foreign");
        }
    }
}
