using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class OrganizacionesRepository : BaseRepository<CoreOrganizaciones>, IOrganizacionRepository
    {
        public OrganizacionesRepository(RadiografiaContext context) : base(context) { }
        
        public IEnumerable<object> GetOrganizacionForReporte()
        {
            var resp = _entities.Include(x => x.IdTipoIdentificacionNavigation).Select(x => new { x.Slug, x.Nombre, x.Identificacion, TipoIdentificacion=x.IdTipoIdentificacionNavigation.Nombre, x.CreatedAt }).AsEnumerable();
            return resp;
        }

        public CoreOrganizaciones getOrganizacion( string org)
        {
            var organizacion = _entities.Where(x => x.Nombre.ToLower() == org.ToLower()).ToList();
            if(organizacion.Count < 1)
            {
                return null;
            }
            return organizacion.First();
        }

    }
}
