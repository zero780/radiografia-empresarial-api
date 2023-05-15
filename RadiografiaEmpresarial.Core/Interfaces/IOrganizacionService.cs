using RadiografiaEmpresarial.Core.CustomEntities;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IOrganizacionService
    {
        PagedList<CoreOrganizaciones> GetOrganizaciones(OrganizacionQueryFilter filters);

        Task<CoreOrganizaciones> GetOrganizacion(long id);

        Task<bool> InsertOrganizacion(CoreOrganizaciones rad, string nomUser);

        Task<bool> UpdateOrganizacion(CoreOrganizaciones org, string nomUser);

        Task<bool> DeleteOrganizacion(long id, string nomUser);
    }
}
