using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class AuthUsuarios : BaseEntity
    {
        public AuthUsuarios()
        {
            AuthRepUsersCreatedByNavigation = new HashSet<AuthRepUsers>();
            AuthRepUsersDeletedByNavigation = new HashSet<AuthRepUsers>();
            AuthRepUsersIdUsuarioNavigation = new HashSet<AuthRepUsers>();
            AuthRepUsersUpdatedByNavigation = new HashSet<AuthRepUsers>();
            AuthRoUsuariosCreatedByNavigation = new HashSet<AuthRoUsuarios>();
            AuthRoUsuariosDeletedByNavigation = new HashSet<AuthRoUsuarios>();
            AuthRoUsuariosIdUsuarioNavigation = new HashSet<AuthRoUsuarios>();
            AuthRoUsuariosUpdatedByNavigation = new HashSet<AuthRoUsuarios>();
            AuthTokenUsuarios = new HashSet<AuthTokenUsuarios>();
            CoreGrIntegrantesCreatedByNavigation = new HashSet<CoreGrIntegrantes>();
            CoreGrIntegrantesDeletedByNavigation = new HashSet<CoreGrIntegrantes>();
            CoreGrIntegrantesIdUsuarioNavigation = new HashSet<CoreGrIntegrantes>();
            CoreGrIntegrantesUpdatedByNavigation = new HashSet<CoreGrIntegrantes>();
            CoreGruposCreatedByNavigation = new HashSet<CoreGrupos>();
            CoreGruposDeletedByNavigation = new HashSet<CoreGrupos>();
            CoreGruposIdSupervisadorNavigation = new HashSet<CoreGrupos>();
            CoreGruposUpdatedByNavigation = new HashSet<CoreGrupos>();
            CoreOrgVinculosCreatedByNavigation = new HashSet<CoreOrgVinculos>();
            CoreOrgVinculosDeletedByNavigation = new HashSet<CoreOrgVinculos>();
            CoreOrgVinculosUpdatedByNavigation = new HashSet<CoreOrgVinculos>();
            CoreOrganizacionesCreatedByNavigation = new HashSet<CoreOrganizaciones>();
            CoreOrganizacionesDeletedByNavigation = new HashSet<CoreOrganizaciones>();
            CoreOrganizacionesUpdatedByNavigation = new HashSet<CoreOrganizaciones>();
            CoreViRepresentanteCreatedByNavigation = new HashSet<CoreViRepresentante>();
            CoreViRepresentanteDeletedByNavigation = new HashSet<CoreViRepresentante>();
            CoreViRepresentanteIdUsuarioNavigation = new HashSet<CoreViRepresentante>();
            CoreViRepresentanteUpdatedByNavigation = new HashSet<CoreViRepresentante>();
            CoreVinculosCreatedByNavigation = new HashSet<CoreVinculos>();
            CoreVinculosDeletedByNavigation = new HashSet<CoreVinculos>();
            CoreVinculosUpdatedByNavigation = new HashSet<CoreVinculos>();
            InverseDeletedByNavigation = new HashSet<AuthUsuarios>();
            RadRadiografiasCreatedByNavigation = new HashSet<RadRadiografias>();
            RadRadiografiasDeletedByNavigation = new HashSet<RadRadiografias>();
            RadRadiografiasUpdatedByNavigation = new HashSet<RadRadiografias>();
        }

        //public long Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Extra { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }

        public virtual AuthUsuarios DeletedByNavigation { get; set; }
        public virtual ICollection<AuthRepUsers> AuthRepUsersCreatedByNavigation { get; set; }
        public virtual ICollection<AuthRepUsers> AuthRepUsersDeletedByNavigation { get; set; }
        public virtual ICollection<AuthRepUsers> AuthRepUsersIdUsuarioNavigation { get; set; }
        public virtual ICollection<AuthRepUsers> AuthRepUsersUpdatedByNavigation { get; set; }
        public virtual ICollection<AuthRoUsuarios> AuthRoUsuariosCreatedByNavigation { get; set; }
        public virtual ICollection<AuthRoUsuarios> AuthRoUsuariosDeletedByNavigation { get; set; }
        public virtual ICollection<AuthRoUsuarios> AuthRoUsuariosIdUsuarioNavigation { get; set; }
        public virtual ICollection<AuthRoUsuarios> AuthRoUsuariosUpdatedByNavigation { get; set; }
        public virtual ICollection<AuthTokenUsuarios> AuthTokenUsuarios { get; set; }
        public virtual ICollection<CoreGrIntegrantes> CoreGrIntegrantesCreatedByNavigation { get; set; }
        public virtual ICollection<CoreGrIntegrantes> CoreGrIntegrantesDeletedByNavigation { get; set; }
        public virtual ICollection<CoreGrIntegrantes> CoreGrIntegrantesIdUsuarioNavigation { get; set; }
        public virtual ICollection<CoreGrIntegrantes> CoreGrIntegrantesUpdatedByNavigation { get; set; }
        public virtual ICollection<CoreGrupos> CoreGruposCreatedByNavigation { get; set; }
        public virtual ICollection<CoreGrupos> CoreGruposDeletedByNavigation { get; set; }
        public virtual ICollection<CoreGrupos> CoreGruposIdSupervisadorNavigation { get; set; }
        public virtual ICollection<CoreGrupos> CoreGruposUpdatedByNavigation { get; set; }
        public virtual ICollection<CoreOrgVinculos> CoreOrgVinculosCreatedByNavigation { get; set; }
        public virtual ICollection<CoreOrgVinculos> CoreOrgVinculosDeletedByNavigation { get; set; }
        public virtual ICollection<CoreOrgVinculos> CoreOrgVinculosUpdatedByNavigation { get; set; }
        public virtual ICollection<CoreOrganizaciones> CoreOrganizacionesCreatedByNavigation { get; set; }
        public virtual ICollection<CoreOrganizaciones> CoreOrganizacionesDeletedByNavigation { get; set; }
        public virtual ICollection<CoreOrganizaciones> CoreOrganizacionesUpdatedByNavigation { get; set; }
        public virtual ICollection<CoreViRepresentante> CoreViRepresentanteCreatedByNavigation { get; set; }
        public virtual ICollection<CoreViRepresentante> CoreViRepresentanteDeletedByNavigation { get; set; }
        public virtual ICollection<CoreViRepresentante> CoreViRepresentanteIdUsuarioNavigation { get; set; }
        public virtual ICollection<CoreViRepresentante> CoreViRepresentanteUpdatedByNavigation { get; set; }
        public virtual ICollection<CoreVinculos> CoreVinculosCreatedByNavigation { get; set; }
        public virtual ICollection<CoreVinculos> CoreVinculosDeletedByNavigation { get; set; }
        public virtual ICollection<CoreVinculos> CoreVinculosUpdatedByNavigation { get; set; }
        public virtual ICollection<AuthUsuarios> InverseDeletedByNavigation { get; set; }
        public virtual ICollection<RadRadiografias> RadRadiografiasCreatedByNavigation { get; set; }
        public virtual ICollection<RadRadiografias> RadRadiografiasDeletedByNavigation { get; set; }
        public virtual ICollection<RadRadiografias> RadRadiografiasUpdatedByNavigation { get; set; }
    }
}
