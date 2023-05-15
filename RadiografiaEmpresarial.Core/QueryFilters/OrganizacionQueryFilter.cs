using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.QueryFilters
{
    public class OrganizacionQueryFilter
    {
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public long? CreatedBy { get; set; }
        public int pageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
