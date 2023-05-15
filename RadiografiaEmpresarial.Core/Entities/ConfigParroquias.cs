using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class ConfigParroquias : BaseEntity
    {
        public ConfigParroquias()
        {
            RadRespuestas11 = new HashSet<RadRespuestas11>();
        }

        //public long Id { get; set; }
        public long IdProvincia { get; set; }
        public long IdCanton { get; set; }
        public string Nombre { get; set; }
        public string CodProvincia { get; set; }
        public string CodCanton { get; set; }
        public string Codigo { get; set; }
        public bool? IsRural { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ConfigCantones IdCantonNavigation { get; set; }
        public virtual ConfigProvincias IdProvinciaNavigation { get; set; }
        public virtual ICollection<RadRespuestas11> RadRespuestas11 { get; set; }
    }
}
