using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoPosicionamientos : BaseEntity
    {
        public TipoPosicionamientos()
        {
            RadRespuestas2HIdCompetenciaNavigation = new HashSet<RadRespuestas2H>();
            RadRespuestas2HIdPosicionamientoNavigation = new HashSet<RadRespuestas2H>();
            RadRespuestas3A = new HashSet<RadRespuestas3A>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<RadRespuestas2H> RadRespuestas2HIdCompetenciaNavigation { get; set; }
        public virtual ICollection<RadRespuestas2H> RadRespuestas2HIdPosicionamientoNavigation { get; set; }
        public virtual ICollection<RadRespuestas3A> RadRespuestas3A { get; set; }
    }
}
