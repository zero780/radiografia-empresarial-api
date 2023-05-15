using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class RadRespuestas4B1 : BaseEntity
    {
        //public long Id { get; set; }
        public long IdOrganizacion { get; set; }
        public long IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public long IdEnergia { get; set; }
        public double Produccion { get; set; }
        public double OtrasAreas { get; set; }
        public double Total { get; set; }
        public long IdEstado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TipoEnergias IdEnergiaNavigation { get; set; }
        public virtual EstadoRespuestas IdEstadoNavigation { get; set; }
        public virtual CoreGrupos IdGrupoNavigation { get; set; }
        public virtual CoreOrganizaciones IdOrganizacionNavigation { get; set; }
        public virtual RadRadiografias IdRadiografiaNavigation { get; set; }
    }
}
