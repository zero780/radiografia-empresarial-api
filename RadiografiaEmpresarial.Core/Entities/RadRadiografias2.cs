using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Entities.EntitiesJoin
{
    public partial class RadRadiografias2 : BaseEntity
    {
        public int id_radiografia { get; set; }
        public string estado_radiografia { get; set; }
        public string nombre_organizacion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
