using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class RadRespuestas6A : BaseEntity
    {
        //public long Id { get; set; }
        public long IdOrganizacion { get; set; }
        public long IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public bool? ExportacionNula { get; set; }
        public bool? ExportacionProdServ { get; set; }
        public bool? ImplantacionComercial { get; set; }
        public bool? ImplantacionProductiva { get; set; }
        public bool? Subcontratacion { get; set; }
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
