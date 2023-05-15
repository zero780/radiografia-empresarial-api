using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IRadiografiaService
    {
        IEnumerable<RadRadiografias> GetRadiografias();
        IEnumerable<object> GetRadiografias2(string query);

        Task<RadRadiografias> GetRadiografia(long id);



        Task InsertRadiografia(RadRadiografias rad);

        Task<bool> UpdateRadiografia(RadRadiografias rad);

        Task<bool> DeleteRadiografia(long id);

        IEnumerable<object> GetSecciones();

        Dictionary<string, object> GetSecciones_Rad(string tabla, long idRad, long idGrupo);

        Task<bool> InsertData_Radiografia_seccion1(RadRespuestas11 seccion1);
        Task<bool> InsertData_Radiografia_seccion2(Seccion2DTO seccion2, string slug);

        Task<bool>  InsertData_Radiografia_seccion1_datosContacto(RadRespuestas11 seccion1);
    }
}