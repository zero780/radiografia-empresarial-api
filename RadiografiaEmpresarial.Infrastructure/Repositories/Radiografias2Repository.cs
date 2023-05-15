using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class Radiografias2Repository : BaseRepository<RadRadiografias2>, IRadiografia2Repository
    {
        public Radiografias2Repository(RadiografiaContext context) : base(context) { }

        
        public IEnumerable<object> GetRadiografiaForReporte()
        {
            return _entities.Include(x => x.estado_radiografia).Include(x => x.nombre_organizacion).Select(x => new { estado = x.estado_radiografia, organizacion = x.nombre_organizacion, x.CreatedAt }).AsEnumerable();
        }

    }
}
