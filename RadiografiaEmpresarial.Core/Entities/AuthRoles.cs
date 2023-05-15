using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class AuthRoles : BaseEntity
    {
        public AuthRoles()
        {
            AuthRoPermisos = new HashSet<AuthRoPermisos>();
            AuthRoUsuarios = new HashSet<AuthRoUsuarios>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<AuthRoPermisos> AuthRoPermisos { get; set; }
        public virtual ICollection<AuthRoUsuarios> AuthRoUsuarios { get; set; }
    }
}
