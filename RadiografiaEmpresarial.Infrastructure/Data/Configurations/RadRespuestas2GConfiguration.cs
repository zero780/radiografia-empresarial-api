using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiografiaEmpresarial.Core.Entities;

namespace RadiografiaEmpresarial.Infrastructure.Data.Configurations
{
    public class RadRespuestas2GConfiguration : IEntityTypeConfiguration<RadRespuestas2G>
    {
        public void Configure(EntityTypeBuilder<RadRespuestas2G> builder)
        {
            builder.ToTable("rad__respuestas_2_g");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CompraInsumos).HasColumnName("compra_insumos");

            builder.Property(e => e.CompraMateriaPrima).HasColumnName("compra_materia_prima");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(e => e.CualesInsumos).HasColumnName("cuales_insumos");

            builder.Property(e => e.CualesInteres).HasColumnName("cuales_interes");

            builder.Property(e => e.CualesMateriaPrima).HasColumnName("cuales_materia_prima");

            builder.Property(e => e.CualesProveedoresI).HasColumnName("cuales_proveedores_i");

            builder.Property(e => e.CualesProveedoresM).HasColumnName("cuales_proveedores_m");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DesarrollarProveedoresI).HasColumnName("desarrollar_proveedores_i");

            builder.Property(e => e.DesarrollarProveedoresM).HasColumnName("desarrollar_proveedores_m");

            builder.Property(e => e.ExisteInteres).HasColumnName("existe_interes");

            builder.Property(e => e.IdCantonInsumos).HasColumnName("id_canton_insumos");

            builder.Property(e => e.IdCantonMateriaPrima).HasColumnName("id_canton_materia_prima");

            builder.Property(e => e.IdCantonProveedoresI).HasColumnName("id_canton_proveedores_i");

            builder.Property(e => e.IdCantonProveedoresM).HasColumnName("id_canton_proveedores_m");

            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.Property(e => e.IdGrupo).HasColumnName("id_grupo");

            builder.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");

            builder.Property(e => e.IdProvinciaInsumos).HasColumnName("id_provincia_insumos");

            builder.Property(e => e.IdProvinciaMateriaPrima).HasColumnName("id_provincia_materia_prima");

            builder.Property(e => e.IdProvinciaProveedoresI).HasColumnName("id_provincia_proveedores_i");

            builder.Property(e => e.IdProvinciaProveedoresM).HasColumnName("id_provincia_proveedores_m");

            builder.Property(e => e.IdRadiografia).HasColumnName("id_radiografia");

            builder.Property(e => e.PorqueInsumos).HasColumnName("porque_insumos");

            builder.Property(e => e.PorqueMateriaPrima).HasColumnName("porque_materia_prima");

            builder.Property(e => e.PorqueProveedoresI).HasColumnName("porque_proveedores_i");

            builder.Property(e => e.PorqueProveedoresM).HasColumnName("porque_proveedores_m");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdCantonInsumosNavigation)
                .WithMany(p => p.RadRespuestas2GIdCantonInsumosNavigation)
                .HasForeignKey(d => d.IdCantonInsumos)
                .HasConstraintName("rad__respuestas_2_g_id_canton_insumos_foreign");

            builder.HasOne(d => d.IdCantonMateriaPrimaNavigation)
                .WithMany(p => p.RadRespuestas2GIdCantonMateriaPrimaNavigation)
                .HasForeignKey(d => d.IdCantonMateriaPrima)
                .HasConstraintName("rad__respuestas_2_g_id_canton_materia_prima_foreign");

            builder.HasOne(d => d.IdCantonProveedoresINavigation)
                .WithMany(p => p.RadRespuestas2GIdCantonProveedoresINavigation)
                .HasForeignKey(d => d.IdCantonProveedoresI)
                .HasConstraintName("rad__respuestas_2_g_id_canton_proveedores_i_foreign");

            builder.HasOne(d => d.IdCantonProveedoresMNavigation)
                .WithMany(p => p.RadRespuestas2GIdCantonProveedoresMNavigation)
                .HasForeignKey(d => d.IdCantonProveedoresM)
                .HasConstraintName("rad__respuestas_2_g_id_canton_proveedores_m_foreign");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.RadRespuestas2G)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_g_id_estado_foreign");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.RadRespuestas2G)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("rad__respuestas_2_g_id_grupo_foreign");

            builder.HasOne(d => d.IdOrganizacionNavigation)
                .WithMany(p => p.RadRespuestas2G)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_g_id_organizacion_foreign");

            builder.HasOne(d => d.IdProvinciaInsumosNavigation)
                .WithMany(p => p.RadRespuestas2GIdProvinciaInsumosNavigation)
                .HasForeignKey(d => d.IdProvinciaInsumos)
                .HasConstraintName("rad__respuestas_2_g_id_provincia_insumos_foreign");

            builder.HasOne(d => d.IdProvinciaMateriaPrimaNavigation)
                .WithMany(p => p.RadRespuestas2GIdProvinciaMateriaPrimaNavigation)
                .HasForeignKey(d => d.IdProvinciaMateriaPrima)
                .HasConstraintName("rad__respuestas_2_g_id_provincia_materia_prima_foreign");

            builder.HasOne(d => d.IdProvinciaProveedoresINavigation)
                .WithMany(p => p.RadRespuestas2GIdProvinciaProveedoresINavigation)
                .HasForeignKey(d => d.IdProvinciaProveedoresI)
                .HasConstraintName("rad__respuestas_2_g_id_provincia_proveedores_i_foreign");

            builder.HasOne(d => d.IdProvinciaProveedoresMNavigation)
                .WithMany(p => p.RadRespuestas2GIdProvinciaProveedoresMNavigation)
                .HasForeignKey(d => d.IdProvinciaProveedoresM)
                .HasConstraintName("rad__respuestas_2_g_id_provincia_proveedores_m_foreign");

            builder.HasOne(d => d.IdRadiografiaNavigation)
                .WithMany(p => p.RadRespuestas2G)
                .HasForeignKey(d => d.IdRadiografia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rad__respuestas_2_g_id_radiografia_foreign");
        }
    }
}
