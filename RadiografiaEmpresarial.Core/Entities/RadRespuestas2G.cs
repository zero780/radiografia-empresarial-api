using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class RadRespuestas2G : BaseEntity
    {
        //public long Id { get; set; }
        public long IdOrganizacion { get; set; }
        public long IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public bool? CompraMateriaPrima { get; set; }
        public long? IdProvinciaMateriaPrima { get; set; }
        public long? IdCantonMateriaPrima { get; set; }
        public string CualesMateriaPrima { get; set; }
        public string PorqueMateriaPrima { get; set; }
        public bool? DesarrollarProveedoresM { get; set; }
        public long? IdProvinciaProveedoresM { get; set; }
        public long? IdCantonProveedoresM { get; set; }
        public string CualesProveedoresM { get; set; }
        public string PorqueProveedoresM { get; set; }
        public bool? CompraInsumos { get; set; }
        public long? IdProvinciaInsumos { get; set; }
        public long? IdCantonInsumos { get; set; }
        public string CualesInsumos { get; set; }
        public string PorqueInsumos { get; set; }
        public bool? DesarrollarProveedoresI { get; set; }
        public long? IdProvinciaProveedoresI { get; set; }
        public long? IdCantonProveedoresI { get; set; }
        public string CualesProveedoresI { get; set; }
        public string PorqueProveedoresI { get; set; }
        public bool? ExisteInteres { get; set; }
        public string CualesInteres { get; set; }
        public long IdEstado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ConfigCantones IdCantonInsumosNavigation { get; set; }
        public virtual ConfigCantones IdCantonMateriaPrimaNavigation { get; set; }
        public virtual ConfigCantones IdCantonProveedoresINavigation { get; set; }
        public virtual ConfigCantones IdCantonProveedoresMNavigation { get; set; }
        public virtual EstadoRespuestas IdEstadoNavigation { get; set; }
        public virtual CoreGrupos IdGrupoNavigation { get; set; }
        public virtual CoreOrganizaciones IdOrganizacionNavigation { get; set; }
        public virtual ConfigProvincias IdProvinciaInsumosNavigation { get; set; }
        public virtual ConfigProvincias IdProvinciaMateriaPrimaNavigation { get; set; }
        public virtual ConfigProvincias IdProvinciaProveedoresINavigation { get; set; }
        public virtual ConfigProvincias IdProvinciaProveedoresMNavigation { get; set; }
        public virtual RadRadiografias IdRadiografiaNavigation { get; set; }
    }
}
