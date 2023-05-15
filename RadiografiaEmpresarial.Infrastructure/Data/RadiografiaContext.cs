using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using RadiografiaEmpresarial.Infrastructure.Data.Configurations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Infrastructure.Data
{
    public partial class RadiografiaContext : DbContext
    {
        public RadiografiaContext(){}

        public RadiografiaContext(DbContextOptions<RadiografiaContext> options)
            : base(options){}

        public virtual DbSet<AuthPermisos> AuthPermisos { get; set; }
        public virtual DbSet<AuthRepUsers> AuthRepUsers { get; set; }
        public virtual DbSet<AuthRoPermisos> AuthRoPermisos { get; set; }
        public virtual DbSet<AuthRoUsuarios> AuthRoUsuarios { get; set; }
        public virtual DbSet<AuthRoles> AuthRoles { get; set; }
        public virtual DbSet<AuthTokenApps> AuthTokenApps { get; set; }
        public virtual DbSet<AuthTokenUsuarios> AuthTokenUsuarios { get; set; }
        public virtual DbSet<AuthUsuarios> AuthUsuarios { get; set; }
        public virtual DbSet<ConfigCantones> ConfigCantones { get; set; }
        public virtual DbSet<ConfigContinentes> ConfigContinentes { get; set; }
        public virtual DbSet<ConfigPaises> ConfigPaises { get; set; }
        public virtual DbSet<ConfigParroquias> ConfigParroquias { get; set; }
        public virtual DbSet<ConfigProvincias> ConfigProvincias { get; set; }
        public virtual DbSet<CoreGrIntegrantes> CoreGrIntegrantes { get; set; }
        public virtual DbSet<CoreGrupos> CoreGrupos { get; set; }
        public virtual DbSet<CoreOrgVinculos> CoreOrgVinculos { get; set; }
        public virtual DbSet<CoreOrganizaciones> CoreOrganizaciones { get; set; }
        public virtual DbSet<CoreViRepresentante> CoreViRepresentante { get; set; }
        public virtual DbSet<CoreVinculos> CoreVinculos { get; set; }
        public virtual DbSet<EstadoGrupos> EstadoGrupos { get; set; }
        public virtual DbSet<EstadoRadiografias> EstadoRadiografias { get; set; }
        public virtual DbSet<EstadoRespuestas> EstadoRespuestas { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<RadRadiografias> RadRadiografias { get; set; }
        public virtual DbSet<RadRadiografias2> RadRadiografias2 { get; set; }
        public virtual DbSet<RadRespuestas11> RadRespuestas11 { get; set; }
        public virtual DbSet<RadRespuestas2A> RadRespuestas2A { get; set; }
        public virtual DbSet<RadRespuestas2B1> RadRespuestas2B1 { get; set; }
        public virtual DbSet<RadRespuestas2B2> RadRespuestas2B2 { get; set; }
        public virtual DbSet<RadRespuestas2C> RadRespuestas2C { get; set; }
        public virtual DbSet<RadRespuestas2D1> RadRespuestas2D1 { get; set; }
        public virtual DbSet<RadRespuestas2D2> RadRespuestas2D2 { get; set; }
        public virtual DbSet<RadRespuestas2E> RadRespuestas2E { get; set; }
        public virtual DbSet<RadRespuestas2F1> RadRespuestas2F1 { get; set; }
        public virtual DbSet<RadRespuestas2F2> RadRespuestas2F2 { get; set; }
        public virtual DbSet<RadRespuestas2G> RadRespuestas2G { get; set; }
        public virtual DbSet<RadRespuestas2H> RadRespuestas2H { get; set; }
        public virtual DbSet<RadRespuestas3A> RadRespuestas3A { get; set; }
        public virtual DbSet<RadRespuestas3B> RadRespuestas3B { get; set; }
        public virtual DbSet<RadRespuestas4A1> RadRespuestas4A1 { get; set; }
        public virtual DbSet<RadRespuestas4A2> RadRespuestas4A2 { get; set; }
        public virtual DbSet<RadRespuestas4B1> RadRespuestas4B1 { get; set; }
        public virtual DbSet<RadRespuestas4B2> RadRespuestas4B2 { get; set; }
        public virtual DbSet<RadRespuestas4C> RadRespuestas4C { get; set; }
        public virtual DbSet<RadRespuestas4D> RadRespuestas4D { get; set; }
        public virtual DbSet<RadRespuestas4E> RadRespuestas4E { get; set; }
        public virtual DbSet<RadRespuestas5A> RadRespuestas5A { get; set; }
        public virtual DbSet<RadRespuestas6A> RadRespuestas6A { get; set; }
        public virtual DbSet<RadRespuestas6B1> RadRespuestas6B1 { get; set; }
        public virtual DbSet<RadRespuestas6B2> RadRespuestas6B2 { get; set; }
        public virtual DbSet<RadRespuestas6C1> RadRespuestas6C1 { get; set; }
        public virtual DbSet<RadRespuestas6C2> RadRespuestas6C2 { get; set; }
        public virtual DbSet<RadRespuestas6D> RadRespuestas6D { get; set; }
        public virtual DbSet<RadRespuestas6E> RadRespuestas6E { get; set; }
        public virtual DbSet<TipoCiius> TipoCiius { get; set; }
        public virtual DbSet<TipoClientes> TipoClientes { get; set; }
        public virtual DbSet<TipoCpcs> TipoCpcs { get; set; }
        public virtual DbSet<TipoEnergias> TipoEnergias { get; set; }
        public virtual DbSet<TipoFrecuencias> TipoFrecuencias { get; set; }
        public virtual DbSet<TipoIdentificaciones> TipoIdentificaciones { get; set; }
        public virtual DbSet<TipoImportancias> TipoImportancias { get; set; }
        public virtual DbSet<TipoIntegrantes> TipoIntegrantes { get; set; }
        public virtual DbSet<TipoJuridicas> TipoJuridicas { get; set; }
        public virtual DbSet<TipoMercados> TipoMercados { get; set; }
        public virtual DbSet<TipoPosicionamientos> TipoPosicionamientos { get; set; }
        public virtual DbSet<TipoReportes> TipoReportes { get; set; }
        public virtual DbSet<TipoRespuestas> TipoRespuestas { get; set; }
        public virtual DbSet<TipoSecciones> TipoSecciones { get; set; }
        public virtual DbSet<TipoSubsecciones> TipoSubsecciones { get; set; }
        public virtual DbSet<TipoSuministros> TipoSuministros { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new authPermisosConfiguration());

            modelBuilder.ApplyConfiguration(new authRepUsersConfiguration());

            modelBuilder.ApplyConfiguration(new AuthRoPermisosConfiguration());

            modelBuilder.ApplyConfiguration(new AuthRoUsuariosConfiguration());

            modelBuilder.ApplyConfiguration(new AuthRolesConfiguration());

            modelBuilder.ApplyConfiguration(new AuthTokenAppsConfiguration());

            modelBuilder.ApplyConfiguration(new AuthTokenUsuariosConfiguration());

            modelBuilder.ApplyConfiguration(new AuthUsuariosConfiguration());

            modelBuilder.ApplyConfiguration(new CoreGrIntegrantesConfiguration());

            modelBuilder.ApplyConfiguration(new CoreGruposConfiguration());

            modelBuilder.ApplyConfiguration(new CoreOrgVinculosConfiguration());

            modelBuilder.ApplyConfiguration(new CoreOrganizacionesConfiguration());

            modelBuilder.ApplyConfiguration(new CoreViRepresentanteConfiguration());

            modelBuilder.ApplyConfiguration(new CoreVinculosConfiguration());

            modelBuilder.ApplyConfiguration(new EstadoGruposConfiguration());

            modelBuilder.ApplyConfiguration(new EstadoRadiografiasConfiguration());

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(255);
            });

            modelBuilder.ApplyConfiguration(new RadRadiografiasConfiguration());

            modelBuilder.ApplyConfiguration(new TipoIdentificacionesConfiguration());

            modelBuilder.ApplyConfiguration(new TipoIntegrantesConfiguration());

            modelBuilder.ApplyConfiguration(new TipoReportesConfiguration());

            modelBuilder.ApplyConfiguration(new TipoSeccionesConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new authPermisosConfiguration());
            modelBuilder.ApplyConfiguration(new authRepUsersConfiguration());
            modelBuilder.ApplyConfiguration(new AuthRoPermisosConfiguration());
            modelBuilder.ApplyConfiguration(new AuthRoUsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new AuthRolesConfiguration());
            modelBuilder.ApplyConfiguration(new AuthTokenAppsConfiguration());
            modelBuilder.ApplyConfiguration(new AuthTokenUsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new AuthUsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigCantonesConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigContinentesConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigPaisesConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigParroquiasConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigProvinciasConfiguration());
            modelBuilder.ApplyConfiguration(new CoreGrIntegrantesConfiguration());
            modelBuilder.ApplyConfiguration(new CoreGruposConfiguration());
            modelBuilder.ApplyConfiguration(new CoreOrgVinculosConfiguration());
            modelBuilder.ApplyConfiguration(new CoreOrganizacionesConfiguration());
            modelBuilder.ApplyConfiguration(new CoreViRepresentanteConfiguration());
            modelBuilder.ApplyConfiguration(new CoreVinculosConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoGruposConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoRadiografiasConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoRespuestasConfiguration());

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(255);
            });

            modelBuilder.ApplyConfiguration(new RadRadiografiasConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas11Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2AConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2B1Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2B2Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2CConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2D1Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2D2Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2EConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2F1Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2F2Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2GConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas2HConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas3AConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas3BConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas4A1Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas4A2Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas4B1Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas4B2Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas4CConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas4DConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas4EConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas5AConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas6AConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas6B1Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas6B2Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas6C1Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas6C2Configuration());
            modelBuilder.ApplyConfiguration(new RadRespuestas6DConfiguration());
            modelBuilder.ApplyConfiguration(new RadRespuestas6EConfiguration());

            modelBuilder.ApplyConfiguration(new TipoCiiusConfiguration());
            modelBuilder.ApplyConfiguration(new TipoClientesConfiguration());
            modelBuilder.ApplyConfiguration(new TipoCpcsConfiguration());
            modelBuilder.ApplyConfiguration(new TipoEnergiasConfiguration());
            modelBuilder.ApplyConfiguration(new TipoFrecuenciasConfiguration());
            modelBuilder.ApplyConfiguration(new TipoIdentificacionesConfiguration());
            modelBuilder.ApplyConfiguration(new TipoImportanciasConfiguration());
            modelBuilder.ApplyConfiguration(new TipoIntegrantesConfiguration());
            modelBuilder.ApplyConfiguration(new TipoJuridicasConfiguration());
            modelBuilder.ApplyConfiguration(new TipoMercadosConfiguration());
            modelBuilder.ApplyConfiguration(new TipoPosicionamientosConfiguration());
            modelBuilder.ApplyConfiguration(new TipoReportesConfiguration());
            modelBuilder.ApplyConfiguration(new TipoRespuestasConfiguration());
            modelBuilder.ApplyConfiguration(new TipoSeccionesConfiguration());
            modelBuilder.ApplyConfiguration(new TipoSubseccionesConfiguration());
            modelBuilder.ApplyConfiguration(new TipoSuministrosConfiguration());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }
}
