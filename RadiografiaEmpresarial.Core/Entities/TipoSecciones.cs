using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoSecciones : BaseEntity
    {
        public TipoSecciones()
        {
            TipoSubsecciones = new HashSet<TipoSubsecciones>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Componente { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<TipoSubsecciones> TipoSubsecciones { get; set; }
    }
}
