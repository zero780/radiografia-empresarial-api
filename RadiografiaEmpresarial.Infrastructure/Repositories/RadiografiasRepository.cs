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
    public class RadiografiasRepository : BaseRepository<RadRadiografias>, IRadiografiaRepository
    {
        public RadiografiasRepository(RadiografiaContext context) : base(context) { }

        public async Task<bool> DeleteRadiografia(long id)
        {
            await Delete(id);
            return true;
        }


        public async Task<RadRadiografias> GetRadiografia(long id)
        {
            return await GetById(id);
        }

        public IEnumerable<object> GetRadiografiaForReporte()
        {
            return _entities.Include(x => x.IdEstadoNavigation).Include(x => x.IdOrganizacionNavigation).Select(x => new { estado = x.IdEstadoNavigation.Nombre, organizacion = x.IdOrganizacionNavigation.Nombre, x.CreatedAt }).AsEnumerable();
        }

        public IEnumerable<RadRadiografias> GetRadiografias()
        {
            return GetAll();
        }

        public IEnumerable<object> getRadiografias2(string query)
        {
            var respuesta = _entities.FromSqlRaw(query).AsEnumerable();
            return respuesta;
        }

        public async Task<RadRadiografias> InsertRadiografia(RadRadiografias rad)
        {
            await Add(rad);
            return rad;
        }

        public bool UpdateRadiografia(RadRadiografias rad)
        {
            Update(rad);
            return true;
        }


        public IEnumerable<object> getRadGrupo(string query)
        {
            var respuesta = _entities.FromSqlRaw(query).AsEnumerable();
            return respuesta;
        }

        public IEnumerable<RadRadiografias> GetRadiografias2(string query)
        {
            var respuesta = _entities.FromSqlRaw(query).AsEnumerable();
            return respuesta;
        }
    }
}
