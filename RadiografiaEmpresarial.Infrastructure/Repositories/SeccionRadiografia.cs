using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class SeccionRadiografia: ISeccionRadiografia
    {
        private readonly RadiografiaContext _context;
        public SeccionRadiografia(RadiografiaContext context)
        {
            _context = context;
        }

        public IEnumerable<RadRespuestas11> seccion1_1(string query)
        {
            var respuesta = _context.RadRespuestas11.FromSqlRaw(query).AsEnumerable();
            return respuesta;
        }

        public IEnumerable<string> seccion1_1Llenados(string query)
        {
            var respuesta = _context.RadRespuestas11.FromSqlRaw(query).AsEnumerable();
            if(respuesta== null)
            {
                return null;
            }

            List<string> column = new List<string>();
            RadRespuestas11 resp = respuesta.First();
            if(resp.NombreComercial.ToString().Length >= 1)
            {
                column.Add("nombre_comercial");
            }
            if(resp.RazonSocial.ToString().Length >= 1)
            {
                column.Add("razon_social");
            }
            if(resp.RepresentanteLegal.ToString().Length >= 1)
            {
                column.Add("representante_legal");
            }
            if(resp.IdTipoIdentificacion.ToString().Length >= 1)
            {
                column.Add("id_tipo_identificacion");
            }
            if(resp.Identificacion.ToString().Length >= 1)
            {
                column.Add("identificacion");
            }
            if(resp.Gerente.ToString().Length >= 1)
            {
                column.Add("gerente");
            }
            if(resp.IdProvincia.ToString().Length >= 1)
            {
                column.Add("id_provincia");
            }
            if(resp.IdCanton.ToString().Length >= 1)
            {
                column.Add("id_canton");
            }
            if(resp.IdParroquia.ToString().Length >= 1)
            {
                column.Add("id_parroquia");
            }
            if(resp.Direccion.ToString().Length >= 1)
            {
                column.Add("direccion");
            }
            if(resp.Web.ToString().Length >= 1)
            {
                column.Add("web");
            }
            if(resp.Email.ToString().Length >= 1)
            {
                column.Add("email");
            }

            return column.AsEnumerable();
        }

        IEnumerable<object> ISeccionRadiografia.radiografia_estado_organizacion(string query)
        {
            return _context.RadRadiografias2.Include(x => x.estado_radiografia).Include(x => x.nombre_organizacion);
        }

        public IEnumerable<RadRespuestas2E> insertarPrueba(string query)
        {
            return _context.RadRespuestas2E.FromSqlRaw(query).AsEnumerable();
        }
    }
}
