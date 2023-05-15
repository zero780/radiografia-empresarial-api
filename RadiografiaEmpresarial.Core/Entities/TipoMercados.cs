using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoMercados : BaseEntity
    {
        public TipoMercados()
        {
            RadRespuestas2E = new HashSet<RadRespuestas2E>();
            RadRespuestas2F1 = new HashSet<RadRespuestas2F1>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<RadRespuestas2E> RadRespuestas2E { get; set; }
        public virtual ICollection<RadRespuestas2F1> RadRespuestas2F1 { get; set; }
    }
}
