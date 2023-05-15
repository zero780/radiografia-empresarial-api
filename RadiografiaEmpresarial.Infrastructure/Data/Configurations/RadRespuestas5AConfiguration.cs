using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas5AConfiguration : IEntityTypeConfiguration<RadRespuestas5A>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas5A> builder)
        {
            builder.ToTable("rad__respuestas_5_a");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CualesFidelizacion).HasColumnName("cuales_fidelizacion");

            builder.Property(e => e.CvComercialMultiproducto)
                .IsRequired()
                .HasColumnName("cv_comercial_multiproducto")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CvComercialPropio)
                .IsRequired()
                .HasColumnName("cv_comercial_propio")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CvComisionista)
                .IsRequired()
                .HasColumnName("cv_comisionista")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CvDistribuidor)
                .IsRequired()
                .HasColumnName("cv_distribuidor")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CvNetworking)
                .IsRequired()
                .HasColumnName("cv_networking")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CvTelemarketing)
                .IsRequired()
                .HasColumnName("cv_telemarketing")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CvVentaDirecta)
                .IsRequired()
                .HasColumnName("cv_venta_directa")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.CvVentaOnline)
                .IsRequired()
                .HasColumnName("cv_venta_online")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.ExisteDefinicion).HasColumnName("existe_definicion");

            builder.Property(e => e.ExisteFidelizacion).HasColumnName("existe_fidelizacion");

            builder.Property(e => e.ExisteInteres).HasColumnName("existe_interes");

            builder.Property(e => e.ExistePlan).HasColumnName("existe_plan");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.RcCatalogos)
                .IsRequired()
                .HasColumnName("rc_catalogos")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.RcFerias)
                .IsRequired()
                .HasColumnName("rc_ferias")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.RcMktDigital)
                .IsRequired()
                .HasColumnName("rc_mkt_digital")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.RcOtros)
                .IsRequired()
                .HasColumnName("rc_otros")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.RcPosicionamientoWeb)
                .IsRequired()
                .HasColumnName("rc_posicionamiento_web")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.RcVideos)
                .IsRequired()
                .HasColumnName("rc_videos")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.RcWeb)
                .IsRequired()
                .HasColumnName("rc_web")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.RcWebTraducida)
                .IsRequired()
                .HasColumnName("rc_web_traducida")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas5A)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_5_a_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas5A)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_5_a_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas5A)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_5_a_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas5A)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_5_a_id_radiografia_foreign");
        }
    }
}
