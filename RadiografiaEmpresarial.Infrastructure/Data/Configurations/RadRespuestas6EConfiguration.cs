using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas6EConfiguration : IEntityTypeConfiguration<RadRespuestas6E>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas6E> builder)
        {
            builder.ToTable("rad__respuestas_6_e");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.AbrirMercadosInt)
                .IsRequired()
                .HasColumnName("abrir_mercados_int")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CualesMercadosInt).HasColumnName("cuales_mercados_int");

            builder.Property(e => e.CualesPaises).HasColumnName("cuales_paises");

            builder.Property(e => e.CualesSectores).HasColumnName("cuales_sectores");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.IntExportacion)
                .IsRequired()
                .HasColumnName("int_exportacion")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.IntImplantacionComercial)
                .IsRequired()
                .HasColumnName("int_implantacion_comercial")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.IntImplantacionProductiva)
                .IsRequired()
                .HasColumnName("int_implantacion_productiva")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.IntImportacion)
                .IsRequired()
                .HasColumnName("int_importacion")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.ZonaAfrica)
                .IsRequired()
                .HasColumnName("zona_africa")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ZonaAsia)
                .IsRequired()
                .HasColumnName("zona_asia")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ZonaCaribe)
                .IsRequired()
                .HasColumnName("zona_caribe")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ZonaCentroamerica)
                .IsRequired()
                .HasColumnName("zona_centroamerica")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ZonaEuropa)
                .IsRequired()
                .HasColumnName("zona_europa")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ZonaNorteamerica)
                .IsRequired()
                .HasColumnName("zona_norteamerica")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ZonaOceania)
                .IsRequired()
                .HasColumnName("zona_oceania")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ZonaSudamerica)
                .IsRequired()
                .HasColumnName("zona_sudamerica")
                .HasDefaultValueSql("('0')");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas6E)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_e_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas6E)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_6_e_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas6E)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_e_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas6E)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_e_id_radiografia_foreign");
        }
    }
}
