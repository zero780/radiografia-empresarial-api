    using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IExcelService _excelService;
        private IHttpContextAccessor _httpContextAccessor;
        private IReportesService _reportesService;
        private readonly IMapper _mapper;

        private string nombreUser;

        public ReportesController(IExcelService excelService, IHttpContextAccessor httpContextAccessor, IReportesService reportesService, IMapper mapper)
        {
            _excelService = excelService;
            _httpContextAccessor = httpContextAccessor;
            _reportesService = reportesService;
            _mapper = mapper;
        }

        [HttpGet("organizaciones")]
        public async Task<IActionResult> GetReportesOrganizacion()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["authorization"].Single().Split(" ").Last();
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;

            if (! await _reportesService.IsPermitted(token,4,nombreUser))
            {
                return Unauthorized("No tiene permiso de administrador o su Sesión ha terminado");
            }

            byte[] data = await _excelService.ReporteOrganizacion();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ReportesExcel","organizaciones.xlsx");
            System.IO.File.WriteAllBytes(filePath, data);
            string file = Convert.ToBase64String(data);
            return Ok(file);
        }

        [HttpGet("grupos-de-trabajo")]//api/reportes/grupos-de-trabajo/
        public async Task<IActionResult> GetGrupos()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["authorization"].Single().Split(" ").Last();
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;

            if (!await _reportesService.IsPermitted(token, 4, nombreUser))
            {
                return Unauthorized("No tiene permiso de Visualizador o su Sesión ha terminado");
            }

            byte[] data = await _excelService.ReporteGrupoTrabajo();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ReportesExcel", "gruposDeTrabajo.xlsx");
            System.IO.File.WriteAllBytes(filePath, data);
            string file = Convert.ToBase64String(data);
            return Ok(file);
        }

        [HttpGet("vinculos")]
        public async Task<IActionResult> GetVinculos()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["authorization"].Single().Split(" ").Last();
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;

            if (!await _reportesService.IsPermitted(token, 4, nombreUser))
            {
                return Unauthorized("No tiene permiso de administrador o su Sesión ha terminado");
            }

            byte[] data = await _excelService.ReporteGrupoTrabajo();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ReportesExcel", "gruposDeTrabajo.xlsx");
            System.IO.File.WriteAllBytes(filePath, data);
            string file = Convert.ToBase64String(data);
            return Ok(file);
        }

        [HttpGet]
        public IActionResult getReportes()
        {
            IEnumerable<TipoReportes> reportes = _reportesService.GetReportes();
            var reportesDTO = _mapper.Map<IEnumerable<TipoReporteDTO>>(reportes);
            var response = new ApiResponse<IEnumerable<TipoReporteDTO>>(reportesDTO);
            return Ok(response);
        }
    
        [HttpPost("{slug}")]
        public IActionResult PostReportes(string slug)
        {
            string result = null;
            Dictionary<string, object> json;
            ApiResponse<Dictionary<string, object>> response;

            try
            {
                result = _httpContextAccessor.HttpContext.Request.Headers["params"].Single();
            }
            catch
            {
                result = null;
            }
            
            if(result != null)
            {
                byte[] resultArray = Convert.FromBase64String(result);

                string jsonback = Encoding.UTF8.GetString(resultArray);
                var resultBack = JsonConvert.DeserializeObject<FilterReporte>(jsonback);
                //Console.WriteLine("Inicio: " + resultBack.FechaInicial + ", Final: " + resultBack.FechaFinal);
                //return Ok(resultBack);
                //json = _reportesService.CreateReport(slug, result);
                //response = new ApiResponse<Dictionary<string,object>>(json);
                //return Ok(response);
            }

            json = _reportesService.CreateReport(slug, result);
            response = new ApiResponse<Dictionary<string, object>>(json);
            return Ok(response);
        }

    }
}
