using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Email;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Exceptions;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Route("api/auth/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenService _tokenService;
        private IConfiguration _configuration;
        private ISendMail _sendMail;
        private IUnitOfWork _unitOfWork;
        private IHttpContextAccessor _httpContextAccessor;

        //Llamo AutoMapper
        private readonly IMapper _mapper;

        public TokenController(ITokenService tokenService, IConfiguration configuration, ISendMail sendMail, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _tokenService = tokenService;
            _configuration = configuration;
            _sendMail = sendMail;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        
        [HttpPost("serviceValidate")]
        public async Task<IActionResult> Authentication(AuthUsuarioDTO user)
        {
            if (user.Email == null) { throw new BusinessException("El e-mail es inválido, ingrese uno correcto."); }
            var user2 = _tokenService.GetUsuarioByEmail(user.Email); //Obtengo el usuario
            if (user2 == null)
            {
                //DEBO CREAR EL USUARIO
                bool userCreate = await _tokenService.PostUserbyEmail(user.Email); //Debo obtener el usuario ingresado
                if (!userCreate)
                {
                    throw new BusinessException("No se pudo crear el usuario");
                }
                var userDTO = _mapper.Map<AuthUsuarios>(user);
                _sendMail.WelcomeMail(userDTO);//debo enviar el usuario nuevo
            }
            user2 = _tokenService.GetUsuarioByEmail(user.Email);
            var token = GenerateToken(user2);          
            return Ok(new { token });
        }

        private string GenerateToken(AuthUsuarios user)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var sigCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sigCredentials);
            var jsonPermisos = _unitOfWork.AuthUsuarioRepository.GetIdRol_Usuario(user).ToString(); //Cambiar, ir al Service del token y ahi llamar al metodo
            
            //Claim
            var claims = new[]
            {
                new Claim("nombre", user.Nombre),
                new Claim("correo", user.Email),
                new Claim("canDo", jsonPermisos),
            };
            
            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(30)
            );

            //Tokens
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        [Authorize]
        [HttpGet("logout")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteToken()
        {
            string nombreUser = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "correo").Value;
            var token = _httpContextAccessor.HttpContext.Request.Headers["authorization"].Single().Split(" ").Last();

            if ( !_tokenService.TokenValid(token))
            {
                return Unauthorized();
            }

            var flag = await _tokenService.EliminarToken(token, nombreUser);
            return Ok(flag);
        }

        
    }
}
