using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoFrecuencias : BaseEntity
    {
        public TipoFrecuencias()
        {
            RadRespuestas4A1IdFrecuenciaDespachosNavigation = new HashSet<RadRespuestas4A1>();
            RadRespuestas4A1IdFrecuenciaRecepcionesNavigation = new HashSet<RadRespuestas4A1>();
            RadRespuestas4A2 = new HashSet<RadRespuestas4A2>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<RadRespuestas4A1> RadRespuestas4A1IdFrecuenciaDespachosNavigation { get; set; }
        public virtual ICollection<RadRespuestas4A1> RadRespuestas4A1IdFrecuenciaRecepcionesNavigation { get; set; }
        public virtual ICollection<RadRespuestas4A2> RadRespuestas4A2 { get; set; }
    }
}
