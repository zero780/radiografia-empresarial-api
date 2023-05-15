using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoIdentificaciones : BaseEntity
    {
        public TipoIdentificaciones()
        {
            CoreOrganizaciones = new HashSet<CoreOrganizaciones>();
            RadRespuestas11 = new HashSet<RadRespuestas11>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<CoreOrganizaciones> CoreOrganizaciones { get; set; }
        public virtual ICollection<RadRespuestas11> RadRespuestas11 { get; set; }
    }
}
