using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IRadiografiaRepository
    {
        IEnumerable<RadRadiografias> GetRadiografias();
        IEnumerable<RadRadiografias> GetRadiografias2(string query);

        Task<RadRadiografias> GetRadiografia(long id);

        Task<RadRadiografias> InsertRadiografia(RadRadiografias rad);

        bool UpdateRadiografia(RadRadiografias rad);

        Task<bool> DeleteRadiografia(long id);

        IEnumerable<object> GetRadiografiaForReporte();

        IEnumerable<object> getRadGrupo(string query);
        //IEnumerable<object> GetSecciones();

    }
}
