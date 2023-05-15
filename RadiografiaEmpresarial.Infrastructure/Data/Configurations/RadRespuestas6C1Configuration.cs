using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas6C1Configuration : IEntityTypeConfiguration<RadRespuestas6C1>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas6C1> builder)
        {
            builder.ToTable("rad__respuestas_6_c1");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Exportacion)
                .IsRequired()
                .HasColumnName("exportacion")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.IdContinente).HasColumnName("id_continente");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdPais).HasColumnName("id_pais");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.ImplantacionComercial)
                .IsRequired()
                .HasColumnName("implantacion_comercial")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ImplantacionProductiva)
                .IsRequired()
                .HasColumnName("implantacion_productiva")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.Importacion)
                .IsRequired()
                .HasColumnName("importacion")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdContinenteNavigation)
                .WithMany(p => p.RadRespuestas6C1IdContinenteNavigation)
                .HasForeignKey(d => d.IdContinente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c1_id_continente_foreign");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas6C1IdEstadoNavigation)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c1_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas6C1)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_6_c1_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas6C1)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c1_id_organizacion_foreign");

            builder.HasOne(d => d.IdPaisNavigation)
                .WithMany(p => p.RadRespuestas6C1IdPaisNavigation)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c1_id_pais_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas6C1)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_c1_id_radiografia_foreign");
        }
    }
}
