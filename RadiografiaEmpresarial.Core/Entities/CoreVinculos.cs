using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class CoreVinculos : BaseEntity
    {
        public CoreVinculos()
        {
            CoreGrupos = new HashSet<CoreGrupos>();
            CoreOrgVinculos = new HashSet<CoreOrgVinculos>();
            CoreViRepresentante = new HashSet<CoreViRepresentante>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public long? DeletedBy { get; set; }

        public virtual AuthUsuarios CreatedByNavigation { get; set; }
        public virtual AuthUsuarios DeletedByNavigation { get; set; }
        public virtual AuthUsuarios UpdatedByNavigation { get; set; }
        public virtual ICollection<CoreGrupos> CoreGrupos { get; set; }
        public virtual ICollection<CoreOrgVinculos> CoreOrgVinculos { get; set; }
        public virtual ICollection<CoreViRepresentante> CoreViRepresentante { get; set; }
    }
}
