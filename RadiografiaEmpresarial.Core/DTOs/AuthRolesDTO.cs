using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.DTOs
{
    public class AuthRolesDTO
    {
        public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
