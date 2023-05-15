using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class RadRespuesta1_1Repository : BaseRepository<RadRespuestas11>, IRadRespuesta1_1Repository
    {
        public RadRespuesta1_1Repository(RadiografiaContext context) : base(context) { }
        public IEnumerable<object> GetRespuesta1_1ForReporte()
        {
            return _entities.Include(x => x.IdEstadoNavigation).Include(x => x.IdCantonNavigation).Include(x => x.IdProvinciaNavigation).Include(x => x.IdParroquiaNavigation).
                Include(x => x.IdEstadoNavigation).Select(x => new { x.NombreComercial, x.RazonSocial, x.RepresentanteLegal, x.Identificacion, tipoIdentificacion = x.IdTipoIdentificacionNavigation.Nombre, x.Gerente, provincia = x.IdProvinciaNavigation.Nombre, canton = x.IdCantonNavigation.Nombre, parroquia = x.IdParroquiaNavigation.Nombre, x.Direccion, x.Web, x.Email, estado = x.IdEstadoNavigation.Nombre }).AsEnumerable();
        }
    }
}
