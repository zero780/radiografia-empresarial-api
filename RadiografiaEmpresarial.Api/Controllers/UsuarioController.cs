using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Route("api/usuarios")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private string nombreUser;
        private IHttpContextAccessor _httpContextAccessor;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            //_unitOfWork = unitOfWork;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: UsuarioController\n** Accion: /\n** GET");
            var token = _httpContextAccessor.HttpContext.Request.Headers["authorization"].Single().Split(" ").Last();
            System.Diagnostics.Debug.WriteLine("** Token: " + token);

            var users = _usuarioService.GetUserAll();
            var userDTO = _mapper.Map<IEnumerable<AuthUsuarioDTO>>(users);
            var response = new ApiResponse<IEnumerable<AuthUsuarioDTO>>(userDTO);
            return Ok(response);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: UsuarioController\n** Accion: /{id}\n** GET\n** Id: " + id);
            var user = _usuarioService.GetByUserandRol(id);
            //var user = await _usuarioService.GetByUser(id);
            //var userDTO = _mapper.Map<AuthUsuarioDTO>(user);
            //var response = new ApiResponse<AuthUsuarioDTO>(userDTO);
            var response = new ApiResponse<object>(user);
            return Ok(response);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthUsuarioDTO userDTO)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: UsuarioController\n** Accion: /\n** POST");
            var user = _mapper.Map<AuthUsuarios>(userDTO);
            var isCreate = await _usuarioService.CreateUser(user);
            if (!isCreate)
            {
                return BadRequest("Usuario no creado");
            }
            var response = new ApiResponse<AuthUsuarios>(user);
            return Ok(response);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]AuthUsuarioDTO userDTO)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: UsuarioController\n** Accion: /{id}\n** PUT\n** Id: " + id);
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            var user = _mapper.Map<AuthUsuarios>(userDTO);
            user.Id = id;
            var currentUser = await _usuarioService.UpdateUser(user,nombreUser);
            
            var response = new ApiResponse<AuthUsuarios>(currentUser);
            return Ok(response);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: UsuarioController\n** Accion: /{id}\n** DELETE\n** Id: " + id);
            nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "nombre").Value;
            bool response = await _usuarioService.DeleteUser(id, nombreUser);
            return Ok(response);
        }


        [HttpPut("{id}/actualizarRol")]
        public async Task<IActionResult> Put_RolUsuario(long id, [FromBody] Dictionary<string, string> rolUsuario)
        {
            string rolNew = rolUsuario["rol"];
            var usuario = await _usuarioService.Update_RolUser(id, rolNew);
            var usuarioDTO = _mapper.Map<AuthUsuarioDTO>(usuario);
            var response = new ApiResponse<AuthUsuarioDTO>(usuarioDTO);
            return Ok(response);
        }

    }
}
