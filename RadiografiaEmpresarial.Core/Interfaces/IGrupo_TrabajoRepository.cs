using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IGrupo_TrabajoRepository : IRepository<CoreGrupos>
    {
        Task<IEnumerable<object>> GetGruposTrabajo();
        Task<object> GetGrupos(long id);
        IEnumerable<object> GetGruposTrabajoByUserId(long userId, long idEstado);
        Task<List<CoreGrupos>> GetAllComplet();
        IEnumerable<CoreGrupos> GetGruposTrabajo_ForUserID(long userID);
    }
}
