using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class CoreViRepresentante : BaseEntity
    {
        //public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long IdVinculo { get; set; }
        public long IdUsuario { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public long? DeletedBy { get; set; }

        public virtual AuthUsuarios CreatedByNavigation { get; set; }
        public virtual AuthUsuarios DeletedByNavigation { get; set; }
        public virtual AuthUsuarios IdUsuarioNavigation { get; set; }
        public virtual CoreVinculos IdVinculoNavigation { get; set; }
        public virtual AuthUsuarios UpdatedByNavigation { get; set; }
    }
}
