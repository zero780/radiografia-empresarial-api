using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IGruposTrabajoService
    {
        Task<IEnumerable<object>> GetGruposTrabajo();

        Task<object> GetGrupoTrabajo(long id);

        Task<AuthUsuarios> HasPermissions(string nom, long idRol);

        IEnumerable<object> GetGrupos(string nom, long idEstado);

        IEnumerable<object> GetGruposActivos(string nom, long estadoId);

        IEnumerable<object> GetGruposPendientes(string nom, long estadoId);

        IEnumerable<object> GetGruposRechazados(string nom, long estadoId);

        IEnumerable<object> GetGruposFinalizados(string nom, long estadoId);

        IEnumerable<object> GetGrupo_UserId_byEstado(long UserId, long estadoId);

        Task<IEnumerable<CoreGrIntegrantes>> GetGrupoTrabajoByIntegranteId(long UserId);

        Task<CoreGrupos> InsertGrupoTrabajo(GrupoTrabajoPersonalizado gt, AuthUsuarios user);

        Task<bool> UpdateGrupoTrabajo(CoreGruposDTO gt, AuthUsuarios user);

        Task<bool> DeleteGrupoTrabajo(long id, AuthUsuarios user);

        IEnumerable<CoreGrupos> GetGrupo_ForUser(string userName);

        IEnumerable<CoreGrupos> GetGrupo_ForUserID(long userID);

        Task<CoreGrupos> UpdateEstadoGrupo(long id, string estado);
    }
}
