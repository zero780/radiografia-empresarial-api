using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Exceptions;
using RadiografiaEmpresarial.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Authorize]
    [Route("api/grupos-de-trabajo")]
    [ApiController]
    public class GruposDeTrabajoController : ControllerBase
    {
        //Llamo clase Interface
        private readonly IGruposTrabajoService _gruposTrabajoService;

        //Llamo AutoMapper
        private readonly IMapper _mapper;

        private string nombreUser;

        public GruposDeTrabajoController(IGruposTrabajoService gruposTrabajoService, IMapper mapper)
        {
            _gruposTrabajoService = gruposTrabajoService;
            _mapper = mapper;

        }

        /// <summary>
        /// Devuelve todos los grupos de trabajos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GruposTrabajosAll>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetGrupo_Trabajos() 
        {
            var grupo = await _gruposTrabajoService.GetGruposTrabajo();
            //var grupoDTO = _mapper.Map<IEnumerable<CoreGruposDTO>>(grupo);
            var response = new ApiResponse<IEnumerable<object>>(grupo);
            return Ok(response);
        }

        /// <summary>
        /// Devuelve el Grupo de Trabajo por el ID enviado como parametro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<GruposTrabajosAll>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetGrupo_Trabajo(long id)
        {
            var grupo = await _gruposTrabajoService.GetGrupoTrabajo(id);
            //var grupoMap = _mapper.Map<CoreGrupos>(grupo);
            var response = new ApiResponse<object>(grupo);
            return Ok(response);
        }


        /// <summary>
        /// Devuelve todos los grupos de trabajo activos del usuario en sesión.
        /// </summary>
        /// <returns></returns>
        [HttpGet("activos")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GruposTrabajosAll>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult GetGrupoActivos()
        {
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            
            long idEstado = 2; //Activado
            var grupo = _gruposTrabajoService.GetGruposActivos(nombreUser, idEstado);
            //var superv = grupo.Where(x => x.IdSupervisador == id).Where(x => x.IdEstado == idEstado);
            var response = new ApiResponse<IEnumerable<object>>(grupo);
            return Ok(response);
        }

        /// <summary>
        /// Devuelve todos los grupos de trabajo pendientes del usuario en sesión.
        /// </summary>
        [HttpGet("pendientes")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GruposTrabajosAll>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult GetGrupoPendientes()
        {
            long idEstado = 1; //Pendientes
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var grupo = _gruposTrabajoService.GetGruposPendientes(nombreUser, idEstado);
            //var superv = grupo.Where(x => x.IdSupervisador == id).Where(x => x.IdEstado == idEstado);
            var response = new ApiResponse<IEnumerable<object>>(grupo);
            return Ok(response);
        }

        /// <summary>
        /// Devuelve todos los grupos de trabajo rechazados del usuario en sesión.
        /// </summary>
        [HttpGet("rechazados")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GruposTrabajosAll>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult GetGrupoRechazadas()
        {
            long idEstado = 3; //Rechazadas
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var grupo = _gruposTrabajoService.GetGruposRechazados(nombreUser, idEstado);
            //var superv = grupo.Where(x => x.IdSupervisador == id).Where(x => x.IdEstado == idEstado);
            var response = new ApiResponse<IEnumerable<object>>(grupo);
            return Ok(response);
        }

        /// <summary>
        /// Devuelve todos los grupos de trabajo finalizados del usuario en sesión.
        /// </summary>
        [HttpGet("finalizados")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GruposTrabajosAll>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult GetGrupoFinalizadas()
        {
            long idEstado = 4; //Finalizadas
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var grupo = _gruposTrabajoService.GetGruposFinalizados(nombreUser, idEstado);
            var response = new ApiResponse<IEnumerable<object>>(grupo);
            return Ok(response);
        }

        /// <summary>
        /// Devuelve todos los grupos por Usuario en la Sesión
        /// </summary>
        [HttpGet("mios")]
        public IActionResult GetGrupo_Usuario()
        {
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var grupo = _gruposTrabajoService.GetGrupo_ForUser(nombreUser);
            var grupoMap = _mapper.Map<IEnumerable<CoreGruposDTO>>(grupo);
            var response = new ApiResponse<IEnumerable<CoreGruposDTO>>(grupoMap);
            return Ok(response);
        }

        /// <summary>
        /// Devuelve todos los grupos por Usuario
        /// </summary>
        [HttpGet("mios/{id}")]
        public IActionResult GetGrupo_Usuario(long id)
        {
            var grupo = _gruposTrabajoService.GetGrupo_ForUserID(id);
            var grupoMap = _mapper.Map<IEnumerable<CoreGruposDTO>>(grupo);
            var response = new ApiResponse<IEnumerable<CoreGruposDTO>>(grupoMap);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza Estado del Grupo de Trabajo
        /// </summary>
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> Grupos_ActualizarEstado( long id, [FromBody] Dictionary<string, string> estado)
        {
            var grupo = await _gruposTrabajoService.UpdateEstadoGrupo(id, estado["estado"]);
            var grupoMap = _mapper.Map<CoreGruposDTO>(grupo);
            var response = new ApiResponse<CoreGruposDTO>(grupoMap);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CoreGruposDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Post(GrupoTrabajoPersonalizado grupo)
        {
            long rolSuper = 3;
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;

            var user = await _gruposTrabajoService.HasPermissions(nombreUser, rolSuper );
            //var grupo = _mapper.Map<CoreGrupos>(grupoDTO);
            if (user == null)
            {
                throw new BusinessException("Usuario no tiene el rol de supervisor");
            }

            CoreGrupos grupoNuevo =  await _gruposTrabajoService.InsertGrupoTrabajo(grupo,user);

            if(grupoNuevo == null)
            {
                return BadRequest();
            }
            var grupoDTO = _mapper.Map<CoreGruposDTO>(grupoNuevo);
            var response = new  ApiResponse<CoreGruposDTO>(grupoDTO);
            return Ok(response);
            
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Put(long id, CoreGruposDTO grupoDTO)
        {
            long idSuperv = 3;
            grupoDTO.Id = id;
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var user = await _gruposTrabajoService.HasPermissions(nombreUser, idSuperv);
            //var grupo = _mapper.Map<CoreGrupos>(grupoDTO);
            if (user == null)
            {
                return Ok(null);
            }

            var grupo = _mapper.Map<CoreGrupos>(grupoDTO);
            var result = await _gruposTrabajoService.UpdateGrupoTrabajo(grupoDTO, user);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Delete(long id)
        {
            long idSuperv = 3;
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var user = await _gruposTrabajoService.HasPermissions(nombreUser, idSuperv);
            //var grupo = _mapper.Map<CoreGrupos>(grupoDTO);
            if (user == null)
            {
                return Ok(null);
            }
            var resultado = await _gruposTrabajoService.DeleteGrupoTrabajo(id, user);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }



    }
}
