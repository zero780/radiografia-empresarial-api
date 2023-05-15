using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class ConfigContinentes : BaseEntity
    {
        public ConfigContinentes()
        {
            ConfigPaises = new HashSet<ConfigPaises>();
        }

        //public long Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Orden { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ConfigPaises> ConfigPaises { get; set; }
    }
}
