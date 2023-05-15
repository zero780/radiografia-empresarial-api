using RadiografiaEmpresarial.Core.QueryFilters;
using System;

namespace RadiografiaEmpresarial.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetOrganizationPagUri(OrganizacionQueryFilter filter, string actionUrl);
    }
}
