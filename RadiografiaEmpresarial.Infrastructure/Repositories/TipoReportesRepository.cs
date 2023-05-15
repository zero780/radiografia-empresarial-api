using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RadiografiaEmpresarial.Core.DTOs;
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
    public class TipoReportesRepository : BaseRepository<TipoReportes>, ITipoReportesRepository
    {
        public TipoReportesRepository(RadiografiaContext context) : base(context) { }

        public string GetConsulta(string slug)
        {
            return _entities.Where(x => x.Slug == slug).Select(x => x.Columnas).First();
        }

        public object GetConfig(string slug)
        {
            var config = _entities.Where(x => x.Slug == slug).Select(x => new { x.Nombre,x.NombreArchivo}).AsEnumerable();
            return config;
        }
        
    }
}
