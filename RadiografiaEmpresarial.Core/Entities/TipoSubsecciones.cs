using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoSubsecciones : BaseEntity
    {
        //public long Id { get; set; }
        public long IdTipoRespuesta { get; set; }
        public long IdSeccion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TipoSecciones IdSeccionNavigation { get; set; }
        public virtual TipoRespuestas IdTipoRespuestaNavigation { get; set; }
    }
}
