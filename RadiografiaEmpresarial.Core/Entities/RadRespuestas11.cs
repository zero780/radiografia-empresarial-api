using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class RadRespuestas11 : BaseEntity
    {
        //public long Id { get; set; }
        public long IdOrganizacion { get; set; }
        public long IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public string RepresentanteLegal { get; set; }
        public long? IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Gerente { get; set; }
        public long? IdProvincia { get; set; }
        public long? IdCanton { get; set; }
        public long? IdParroquia { get; set; }
        public string Direccion { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public long IdEstado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ConfigCantones IdCantonNavigation { get; set; }
        public virtual EstadoRespuestas IdEstadoNavigation { get; set; }
        public virtual CoreGrupos IdGrupoNavigation { get; set; }
        public virtual CoreOrganizaciones IdOrganizacionNavigation { get; set; }
        public virtual ConfigParroquias IdParroquiaNavigation { get; set; }
        public virtual ConfigProvincias IdProvinciaNavigation { get; set; }
        public virtual RadRadiografias IdRadiografiaNavigation { get; set; }
        public virtual TipoIdentificaciones IdTipoIdentificacionNavigation { get; set; }
    }
}
