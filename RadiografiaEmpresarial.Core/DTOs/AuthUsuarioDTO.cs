using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.DTOs
{
    public class AuthUsuarioDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Extra { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
