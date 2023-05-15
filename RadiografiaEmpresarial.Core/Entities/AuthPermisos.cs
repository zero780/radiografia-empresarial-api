using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class AuthPermisos : BaseEntity
    {
        public AuthPermisos()
        {
            AuthRoPermisos = new HashSet<AuthRoPermisos>();
        }

        //public long Id { get; set; }
        public string Modelo { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<AuthRoPermisos> AuthRoPermisos { get; set; }
    }
}
