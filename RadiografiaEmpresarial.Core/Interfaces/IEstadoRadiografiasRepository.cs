using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IEstadoRadiografiasRepository
    {
        Task<IEnumerable<EstadoRadiografias>> GetEstadoRadiografias();

        Task<EstadoRadiografias> GetEstadoRadiografia(long id);

        Task<EstadoRadiografias> InsertEstadoRadiografia(EstadoRadiografias es_rad);

        Task<bool> UpdateEstadoRadiografia(EstadoRadiografias es_rad);

        Task<bool> DeleteEstadoRadiografia(long id);
    }
}
