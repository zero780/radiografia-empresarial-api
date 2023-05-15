using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.DTOs
{
    class LevantarInformacionDTO
    {
        public long Id { get; set; }
        public long? IdOrganizacion { get; set; }
        public long? IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public long? IdEstado { get; set; }
        
    }
}
