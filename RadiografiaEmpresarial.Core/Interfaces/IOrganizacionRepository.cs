using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IOrganizacionRepository : IRepository<CoreOrganizaciones>
    {
        IEnumerable<object> GetOrganizacionForReporte();
        CoreOrganizaciones getOrganizacion(string org);
    }
}
