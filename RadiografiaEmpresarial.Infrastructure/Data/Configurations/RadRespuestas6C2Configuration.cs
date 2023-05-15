using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas6C2Configuration : IEntityTypeConfiguration<RadRespuestas6C2>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas6C2> builder)
        {
            builder.ToTable("rad__respuestas_6_c2");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CualesOtros).HasColumnName("cuales_otros");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.EstrategiaComision)
                .IsRequired()
                .HasColumnName("estrategia_comision")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.EstrategiaDirecto)
                .IsRequired()
                .HasColumnName("estrategia_directo")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.EstrategiaDistribuidores)
                .IsRequired()
                .HasColumnName("estrategia_distribuidores")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.EstrategiaOtros)
                .IsRequired()
                .HasColumnName("estrategia_otros")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas6C2)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c2_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas6C2)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_6_c2_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas6C2)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c2_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas6C2)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c2_id_radiografia_foreign");
        }
    }
}
