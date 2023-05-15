using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class AuthRoPermisos : BaseEntity
    {
        //public long Id { get; set; }
        public long IdRol { get; set; }
        public long IdPermiso { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual AuthPermisos IdPermisoNavigation { get; set; }
        public virtual AuthRoles IdRolNavigation { get; set; }
    }
}
