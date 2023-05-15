using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class ConfigCantones : BaseEntity
    {
        public ConfigCantones()
        {
            ConfigParroquias = new HashSet<ConfigParroquias>();
            RadRespuestas11 = new HashSet<RadRespuestas11>();
            RadRespuestas2GIdCantonInsumosNavigation = new HashSet<RadRespuestas2G>();
            RadRespuestas2GIdCantonMateriaPrimaNavigation = new HashSet<RadRespuestas2G>();
            RadRespuestas2GIdCantonProveedoresINavigation = new HashSet<RadRespuestas2G>();
            RadRespuestas2GIdCantonProveedoresMNavigation = new HashSet<RadRespuestas2G>();
        }

        //public long Id { get; set; }
        public long IdProvincia { get; set; }
        public string Nombre { get; set; }
        public string CodProvincia { get; set; }
        public string Codigo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ConfigProvincias IdProvinciaNavigation { get; set; }
        public virtual ICollection<ConfigParroquias> ConfigParroquias { get; set; }
        public virtual ICollection<RadRespuestas11> RadRespuestas11 { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdCantonInsumosNavigation { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdCantonMateriaPrimaNavigation { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdCantonProveedoresINavigation { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdCantonProveedoresMNavigation { get; set; }
    }
}
