using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IGrupoIntegranteRepository : IRepository<CoreGrIntegrantes>
    {
        Task<IEnumerable<CoreGrIntegrantes>> GetGrupoIntegranteByUser(long UserId);
    }
}
