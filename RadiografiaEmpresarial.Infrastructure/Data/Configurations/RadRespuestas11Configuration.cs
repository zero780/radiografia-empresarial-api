using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas11Configuration : IEntityTypeConfiguration<RadRespuestas11>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas11> builder)
        {
            builder.ToTable("rad__respuestas_1_1");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Direccion).HasColumnName("direccion");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(500);

            builder.Property(e => e.Gerente)
                .HasColumnName("gerente")
                .HasMaxLength(500);

            builder.Property(e => e.IdCanton).HasColumnName("id_canton");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdParroquia).HasColumnName("id_parroquia");

            builder.Property(e => e.IdProvincia).HasColumnName("id_provincia");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.IdTipoIdentificacion).HasColumnName("id_tipo_identificacion");

            builder.Property(e => e.Identificacion)
                .HasColumnName("identificacion")
                .HasMaxLength(50);

            builder.Property(e => e.NombreComercial)
                .HasColumnName("nombre_comercial")
                .HasMaxLength(500);

            builder.Property(e => e.RazonSocial)
                .HasColumnName("razon_social")
                .HasMaxLength(500);

            builder.Property(e => e.RepresentanteLegal)
                .HasColumnName("representante_legal")
                .HasMaxLength(500);

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.Web)
                .HasColumnName("web")
                .HasMaxLength(500);

            builder.HasOne(d => d.IdCantonNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdCanton)
                .HasConstraintName("rad__respuestas_1_1_id_canton_foreign");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_1_1_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_1_1_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_1_1_id_organizacion_foreign");

            builder.HasOne(d => d.IdParroquiaNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdParroquia)
                .HasConstraintName("rad__respuestas_1_1_id_parroquia_foreign");

            builder.HasOne(d => d.IdProvinciaNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("rad__respuestas_1_1_id_provincia_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_1_1_id_radiografia_foreign");

            builder.HasOne(d => d.IdTipoIdentificacionNavigation)
                .WithMany(p => p.RadRespuestas11)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .HasConstraintName("rad__respuestas_1_1_id_tipo_identificacion_foreign");
        }
    }
}
