using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RadiografiaController : ControllerBase
    {
        private readonly IRadiografiaService _radiografiaService;
        public RadiografiaController(IRadiografiaService radiografiaService)
        {
            _radiografiaService = radiografiaService;
        }

        [HttpGet]
        public IActionResult GetRadiografias()
        {
            var rad = _radiografiaService.GetRadiografias();
            //var grupoDTO = _mapper.Map<IEnumerable<CoreGruposDTO>>(grupo);
            var response = new ApiResponse<IEnumerable<RadRadiografias>>(rad);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRadiografia(long id)
        {
            var rad = await _radiografiaService.GetRadiografia(id);
            //var grupoDTO = _mapper.Map<CoreGruposDTO>(grupo);
            var response = new ApiResponse<RadRadiografias>(rad);
            return Ok(response);
        }

        [HttpGet("secciones")]
        public IActionResult GetSeccion()
        {
            IEnumerable<object> secciones = _radiografiaService.GetSecciones();
            var response = new ApiResponse<object>(secciones);
            return Ok(response);
        }

        [HttpGet("{idRadiografia}/grupo/{idGrupo}/seccion/{slug}")]
        public IActionResult GetSecciones_Rad(long idRadiografia, long idGrupo, string slug)
        {
            string tabla = null;
            switch (slug)
            {
                case "01-contacto":
                    tabla = "rad__respuestas_1_1";
                    var resp = _radiografiaService.GetSecciones_Rad(tabla, idRadiografia, idGrupo);
                    var response = new ApiResponse<Dictionary<string, object>>(resp);
                    return Ok(response);

                default:
                    return Ok(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RadRadiografias radiografia)
        {
            //var grupo = _mapper.Map<CoreGrupos>(grupoDTO);
            await _radiografiaService.InsertRadiografia(radiografia);

            //grupoDTO = _mapper.Map<CoreGruposDTO>(grupo);
            //var response = new ApiResponse<RadRadiografias>(org);
            return Ok(radiografia);
            
        }

        [HttpPut]
        public async Task<IActionResult> Put(long id, RadRadiografias rad)
        {
           
            //var grupo = _mapper.Map<CoreGrupos>(grupoDTO);

            var result = await _radiografiaService.UpdateRadiografia(rad);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
           
            //return BadRequest();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var resultado = await _radiografiaService.DeleteRadiografia(id);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }

        [HttpPost("seccion/01-contacto/subsection/{slug}")]
        public async Task<IActionResult> InsertData_Radiografia_seccion1(RadRespuestas11 seccion1, string slug)
        {
            bool flag = false;
            switch (slug)
            {
                case "datos-contacto":
                    flag = await _radiografiaService.InsertData_Radiografia_seccion1(seccion1);
                    return Ok(new ApiResponse<bool>(flag));

                default:
                    return Ok(new ApiResponse<bool>(flag));
            }
        }

        [HttpPost("seccion/02-actividad/subsection/{slug}")]
        public async Task<IActionResult> InsertData_Radiografia_seccion2(Seccion2DTO seccion2, string slug)
        {
            bool flag = await _radiografiaService.InsertData_Radiografia_seccion2(seccion2,slug);
            return Ok(new ApiResponse<bool>(flag));
            
        }


    }
}
    