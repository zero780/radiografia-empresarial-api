using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class RadRespuestas6E : BaseEntity
    {
        //public long Id { get; set; }
        public long IdOrganizacion { get; set; }
        public long IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public bool? AbrirMercadosInt { get; set; }
        public string CualesMercadosInt { get; set; }
        public bool? IntExportacion { get; set; }
        public bool? IntImplantacionComercial { get; set; }
        public bool? IntImplantacionProductiva { get; set; }
        public bool? IntImportacion { get; set; }
        public bool? ZonaSudamerica { get; set; }
        public bool? ZonaCentroamerica { get; set; }
        public bool? ZonaCaribe { get; set; }
        public bool? ZonaNorteamerica { get; set; }
        public bool? ZonaEuropa { get; set; }
        public bool? ZonaAfrica { get; set; }
        public bool? ZonaAsia { get; set; }
        public bool? ZonaOceania { get; set; }
        public string CualesPaises { get; set; }
        public string CualesSectores { get; set; }
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
