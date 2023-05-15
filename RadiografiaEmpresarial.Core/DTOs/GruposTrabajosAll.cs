using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.DTOs
{
    public class GruposTrabajosAll
    {
        public long Id { get; set; }
        public long Idestado { get; set; }
        public string Estado { get; set; }
        public long Idorganizacion { get; set; }
        public string Organizacion { get; set; }
        public long Idvinculo { get; set; }
        public string Vinculo { get; set; }
        public long Idsupervisor { get; set; }
        public string Supervisor { get; set; }
        public string MotivoSolicitud { get; set; }
        public string MotivoRespuesta { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CantidadIntegrantes { get; set; }
        public virtual ICollection<IntegrantePersonal> Integrantes { get; set; }

    }


    public class IntegrantePersonal
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
    }

}
