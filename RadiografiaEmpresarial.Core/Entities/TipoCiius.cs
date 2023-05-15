using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoCiius : BaseEntity
    {
        public TipoCiius()
        {
            RadRespuestas2B1 = new HashSet<RadRespuestas2B1>();
            RadRespuestas2B2 = new HashSet<RadRespuestas2B2>();
        }

        //public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Version { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<RadRespuestas2B1> RadRespuestas2B1 { get; set; }
        public virtual ICollection<RadRespuestas2B2> RadRespuestas2B2 { get; set; }
    }
}
