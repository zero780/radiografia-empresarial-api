using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas6B1Configuration : IEntityTypeConfiguration<RadRespuestas6B1>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas6B1> builder)
        {
            builder.ToTable("rad__respuestas_6_b1");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CualesOtros).HasColumnName("cuales_otros");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.InterClientes)
                .IsRequired()
                .HasColumnName("inter_clientes")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.InterIniciativaPropia)
                .IsRequired()
                .HasColumnName("inter_iniciativa_propia")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.InterOtros)
                .IsRequired()
                .HasColumnName("inter_otros")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas6B1)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_b1_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas6B1)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_6_b1_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas6B1)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_b1_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas6B1)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_b1_id_radiografia_foreign");
        }
    }
}
