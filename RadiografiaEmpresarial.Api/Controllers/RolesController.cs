using AutoMapper;
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
using System.Security.Claims;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private string nombreUser;
        public RolesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<VinculosController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: RolesController\n** Accion: /\n** GET");
            /*nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            bool isAdmin = await _unitOfWork.AuthUsuarioRepository.isAdmin(nombreUser);
            if (!isAdmin)
            {
                return Unauthorized("No tiene permisos para ver los Roles");
            }*/
            var roles = _unitOfWork.RolesRepository.GetAll();
            var rolesDTO = _mapper.Map<IEnumerable<AuthRolesDTO>>(roles);
            var response = new ApiResponse<IEnumerable<AuthRolesDTO>>(rolesDTO);
            return Ok(response);
        }
    }
}
