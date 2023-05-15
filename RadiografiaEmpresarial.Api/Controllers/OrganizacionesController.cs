using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.CustomEntities;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Core.QueryFilters;
using RadiografiaEmpresarial.Core.Services;
using RadiografiaEmpresarial.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizacionesController : ControllerBase
    {
        private readonly IOrganizacionService _organizacionService;
        private readonly IUriService _uriService;
        private readonly ITokenService _tokenService;
        private IHttpContextAccessor _httpContextAccessor;

        private string nombreUser;

        public OrganizacionesController(IOrganizacionService organizacionService, IUriService uriService, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _organizacionService = organizacionService;
            _uriService = uriService;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet(Name = nameof(GetOrganizaciones))]
        public IActionResult GetOrganizaciones([FromQuery] OrganizacionQueryFilter filter)
        {

            var org = _organizacionService.GetOrganizaciones(filter);
            //var grupoDTO = _mapper.Map<IEnumerable<CoreGruposDTO>>(grupo);
            //var response = new ApiResponse<PagedList<CoreOrganizaciones>>(org);

            var metadata = new MetaData
            {
                TotalCount = org.TotalCount,
                PageSize = org.PageSize,
                CurrentPage = org.CurrentPage,
                TotalPages = org.TotalPages,
                HasNextPage = org.HasNextPage,
                HasPreviousPage = org.HasPreviousPage,
                NextPageUrl = _uriService.GetOrganizationPagUri(filter, Url.RouteUrl(nameof(GetOrganizaciones))).ToString(),
                PreviousPageUrl = _uriService.GetOrganizationPagUri(filter, Url.RouteUrl(nameof(GetOrganizaciones))).ToString()
            };
            
            var response = new ApiResponse<IEnumerable<CoreOrganizaciones>>(org)
            {
                Meta = metadata
            };

            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizacion(long id)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["authorization"].Single().Split(" ").Last();
            if (!_tokenService.TokenValid(token))
            {
                return Unauthorized();
            }

            var org = await _organizacionService.GetOrganizacion(id);
            //var grupoDTO = _mapper.Map<CoreGruposDTO>(grupo);
            var response = new ApiResponse<CoreOrganizaciones>(org);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CoreOrganizaciones organizacion)
        {
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;

            bool isCreate = await _organizacionService.InsertOrganizacion(organizacion, nombreUser);

            //grupoDTO = _mapper.Map<CoreGruposDTO>(grupo);
            var response = new ApiResponse<CoreOrganizaciones>(organizacion);
            return Ok(response);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, CoreOrganizaciones organizacion)
        {
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value; 
            organizacion.Id = id;
            var result = await _organizacionService.UpdateOrganizacion(organizacion,nombreUser);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var resultado = await _organizacionService.DeleteOrganizacion(id, nombreUser);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }
    }
}
