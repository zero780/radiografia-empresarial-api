using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class ConfigPaises : BaseEntity
    {
        public ConfigPaises()
        {
            ConfigProvincias = new HashSet<ConfigProvincias>();
        }

        //public long Id { get; set; }
        public long? IdContinente { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Orden { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ConfigContinentes IdContinenteNavigation { get; set; }
        public virtual ICollection<ConfigProvincias> ConfigProvincias { get; set; }
    }
}
