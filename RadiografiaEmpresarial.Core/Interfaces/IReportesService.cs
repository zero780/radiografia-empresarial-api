using RadiografiaEmpresarial.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IReportesService
    {
        Task<bool> IsPermitted(string token, long idRol, string email);
        IEnumerable<TipoReportes> GetReportes();
        Dictionary<string, object> CreateReport(string slug, string param);
    }
}
