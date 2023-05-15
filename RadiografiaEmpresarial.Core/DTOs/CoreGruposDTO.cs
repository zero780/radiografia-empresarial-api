using System;

namespace RadiografiaEmpresarial.Core.DTOs
{
    public class CoreGruposDTO
    {
        public long Id { get; set; }
        public long? IdEstado { get; set; }
        public long? IdOrganizacion { get; set; }
        public long? IdVinculo { get; set; }
        public long? IdSupervisador { get; set; }
        public string MotivoSolicitud { get; set; }
        public string MotivoRespuesta { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public long? DeletedBy { get; set; }
    }
}
