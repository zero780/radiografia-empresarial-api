using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.DTOs
{
    public class GrupoTrabajoPersonalizado
    {
        public string Organizacion { get; set; } //nombre organización
        public string Vinculo { get; set; } //slug
        public string MotivoCreacion { get; set; }
        public string MotivoAceptacion { get; set; }
        public virtual ICollection<AuthUsuarioTipoDTO> Integrantes { get; set; }
    }
}
