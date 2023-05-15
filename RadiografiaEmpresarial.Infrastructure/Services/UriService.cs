using RadiografiaEmpresarial.Core.QueryFilters;
using RadiografiaEmpresarial.Infrastructure.Interfaces;
using System;

namespace RadiografiaEmpresarial.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        
        public Uri GetOrganizationPagUri(OrganizacionQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    
    }
}
