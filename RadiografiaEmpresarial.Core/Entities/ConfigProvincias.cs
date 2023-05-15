using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class ConfigProvincias : BaseEntity
    {
        public ConfigProvincias()
        {
            ConfigCantones = new HashSet<ConfigCantones>();
            ConfigParroquias = new HashSet<ConfigParroquias>();
            RadRespuestas11 = new HashSet<RadRespuestas11>();
            RadRespuestas2GIdProvinciaInsumosNavigation = new HashSet<RadRespuestas2G>();
            RadRespuestas2GIdProvinciaMateriaPrimaNavigation = new HashSet<RadRespuestas2G>();
            RadRespuestas2GIdProvinciaProveedoresINavigation = new HashSet<RadRespuestas2G>();
            RadRespuestas2GIdProvinciaProveedoresMNavigation = new HashSet<RadRespuestas2G>();
        }

        //public long Id { get; set; }
        public long IdPais { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ConfigPaises IdPaisNavigation { get; set; }
        public virtual ICollection<ConfigCantones> ConfigCantones { get; set; }
        public virtual ICollection<ConfigParroquias> ConfigParroquias { get; set; }
        public virtual ICollection<RadRespuestas11> RadRespuestas11 { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdProvinciaInsumosNavigation { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdProvinciaMateriaPrimaNavigation { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdProvinciaProveedoresINavigation { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2GIdProvinciaProveedoresMNavigation { get; set; }
    }
}
