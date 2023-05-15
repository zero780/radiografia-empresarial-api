using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas6AConfiguration : IEntityTypeConfiguration<RadRespuestas6A>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas6A> builder)
        {
            builder.ToTable("rad__respuestas_6_a");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.ExportacionNula)
                .IsRequired()
                .HasColumnName("exportacion_nula")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ExportacionProdServ)
                .IsRequired()
                .HasColumnName("exportacion_prod_serv")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.ImplantacionComercial)
                .IsRequired()
                .HasColumnName("implantacion_comercial")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.ImplantacionProductiva)
                .IsRequired()
                .HasColumnName("implantacion_productiva")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.Subcontratacion)
                .IsRequired()
                .HasColumnName("subcontratacion")
                .HasDefaultValueSql("('0')");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas6A)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_a_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas6A)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_6_a_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas6A)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_a_id_organizacion_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas6A)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_6_a_id_radiografia_foreign");
        }
    }
}
