using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.DTOs
{
    public class Seccion2CDTO
    {
        public string Producto { get; set; }
        public double? Facturacion { get; set; }
        public bool? EsPDisenoPropio { get; set; }
        public bool? EsPBajoPlano { get; set; }
        public bool? EsPSubcontratado { get; set; }
        public bool? EsSPropio { get; set; }
        public bool? EsSSubcontratado { get; set; }
    }
}
