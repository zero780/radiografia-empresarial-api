using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RadRadiografiasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RadRadiografiasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<RadRadiografiasController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: RadRadiografiasController\n** Accion: /\n** GET");

            IEnumerable<RadRadiografias> listadoRadiografias = _unitOfWork.RadRadiografiasRepository.GetAll();
            IEnumerable<EstadoRadiografias> listadoEstado = _unitOfWork.estadoRadiografiasRepository.GetAll();
            IEnumerable<CoreOrganizaciones> listadOrganizaciones = _unitOfWork.OrganizacionesRepository.GetAll();
            //IEnumerable<RadRadiografias> listadoFinal =new IEnumerable<object>;

            List<Object> coincidencias = new List<object>();


            for(int i = 0; i < listadoRadiografias.Count(); i += 1)
            {
                RadRadiografias rad = listadoRadiografias.ElementAt(i);
                for(int j=0; j < listadoEstado.Count(); j += 1)
                {
                    EstadoRadiografias est = listadoEstado.ElementAt(j);
                    for (int k = 0; k < listadOrganizaciones.Count(); k += 1)
                    {
                        CoreOrganizaciones org = listadOrganizaciones.ElementAt(k);
                        if (rad.IdEstado == est.Id && rad.IdOrganizacion == org.Id)
                        {
                            System.Diagnostics.Debug.WriteLine("Rad: " + rad.Id.ToString()+est.Nombre+org.Nombre);
                            //Create my object
                            var myData = new
                            {
                                id_radiografia = rad.Id,
                                id_organizacion =org.Id,
                                estado_nombre = est.Nombre,
                                organizacion_nombre = org.Nombre,
                                created_at = est.CreatedAt,
                                updated_at =est.UpdatedAt,
                                deleted_at= est.DeletedAt,
                            };

                            coincidencias.Add(myData);
                        }
                    }
                    
                }
            }

            return Ok(coincidencias);
        }

        [HttpGet("rad_supervisor/{idSupervisado}")]
        public IActionResult GetradiografiasSupervisor(long idSupervisado)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: RadRadiografiasController\n** Accion: /\n** GET");

            IEnumerable<RadRadiografias> listadoRadiografias = _unitOfWork.RadRadiografiasRepository.GetAll();
            IEnumerable<CoreGrupos> listadoGrupos = _unitOfWork.GrupostrabajoRepository.GetAll();
            IEnumerable<EstadoRadiografias> listadoEstado = _unitOfWork.estadoRadiografiasRepository.GetAll();
            IEnumerable<CoreOrganizaciones> listadoOrganizaciones = _unitOfWork.OrganizacionesRepository.GetAll();
            
            //IEnumerable<RadRadiografias> listadoFinal =new IEnumerable<object>;

            List<Object> coincidencias = new List<object>();


            for (int i = 0; i < listadoRadiografias.Count(); i += 1)
            {
                RadRadiografias rad = listadoRadiografias.ElementAt(i);
                for (int j = 0; j < listadoGrupos.Count(); j += 1)
                {
                    CoreGrupos grup = listadoGrupos.ElementAt(j);
                    if (rad.IdOrganizacion==grup.IdOrganizacion && grup.IdSupervisador==idSupervisado)
                    {
                        string nombreEstado = "";
                        //buscando el nombre del estado y de la organizacion
                        for(int t = 0; t < listadoEstado.Count(); t += 1)
                        {
                            EstadoRadiografias est = listadoEstado.ElementAt(t);
                            if (est.Id == rad.IdEstado)
                            {
                                nombreEstado = est.Nombre;
                            }    
                        }

                        string nombreOrganizacion = "";
                        //buscando el nombre del estado y de la organizacion
                        for (int u = 0; u < listadoOrganizaciones.Count(); u += 1)
                        {
                            CoreOrganizaciones org = listadoOrganizaciones.ElementAt(u);
                            if (org.Id == rad.IdOrganizacion)
                            {
                                nombreOrganizacion = org.Nombre;
                            }
                        }

                        System.Diagnostics.Debug.WriteLine("Rad: " + rad.Id.ToString() + grup.Id + grup.IdOrganizacion);
                        //Create my object
                        var myData = new
                        {
                            id_radiografia = rad.Id,
                            id_organizacion = rad.IdOrganizacion,
                            id_grupo = grup.Id,
                            id_estado = rad.IdEstado,
                            nombre_estado =nombreEstado,
                            nombre_organizacion =nombreOrganizacion,
                            created_at = rad.CreatedAt,
                            updated_at = rad.UpdatedAt,
                            deleted_at = rad.DeletedAt,
                        };

                        coincidencias.Add(myData);

                    }
                    

                }

                
            }

            return Ok(coincidencias);
        }
    }
}
