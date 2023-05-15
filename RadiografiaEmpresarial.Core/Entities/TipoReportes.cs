using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class TipoReportes : BaseEntity
    {
        public TipoReportes()
        {
            AuthRepUsers = new HashSet<AuthRepUsers>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string NombreArchivo { get; set; }
        public string Componente { get; set; }
        public string Url { get; set; }
        public string Columnas { get; set; }
        public string Consulta { get; set; }
        public int Orden { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AuthRepUsers> AuthRepUsers { get; set; }
    }
}
