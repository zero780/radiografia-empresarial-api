using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class RadRespuestas5A : BaseEntity
    {
        //public long Id { get; set; }
        public long IdOrganizacion { get; set; }
        public long IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public bool? ExisteDefinicion { get; set; }
        public bool? ExistePlan { get; set; }
        public bool? ExisteInteres { get; set; }
        public bool? CvComercialPropio { get; set; }
        public bool? CvComercialMultiproducto { get; set; }
        public bool? CvDistribuidor { get; set; }
        public bool? CvComisionista { get; set; }
        public bool? CvVentaDirecta { get; set; }
        public bool? CvNetworking { get; set; }
        public bool? CvTelemarketing { get; set; }
        public bool? CvVentaOnline { get; set; }
        public bool? RcWeb { get; set; }
        public bool? RcWebTraducida { get; set; }
        public bool? RcVideos { get; set; }
        public bool? RcCatalogos { get; set; }
        public bool? RcMktDigital { get; set; }
        public bool? RcPosicionamientoWeb { get; set; }
        public bool? RcFerias { get; set; }
        public bool? RcOtros { get; set; }
        public bool? ExisteFidelizacion { get; set; }
        public string CualesFidelizacion { get; set; }
        public long IdEstado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual EstadoRespuestas IdEstadoNavigation { get; set; }
        public virtual CoreGrupos IdGrupoNavigation { get; set; }
        public virtual CoreOrganizaciones IdOrganizacionNavigation { get; set; }
        public virtual RadRadiografias IdRadiografiaNavigation { get; set; }
    }
}
