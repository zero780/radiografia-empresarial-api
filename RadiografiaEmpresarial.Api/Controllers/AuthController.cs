using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.Email;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Exceptions;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Core.Utils;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly ITokenService _tokenService;
        protected readonly IConfiguration _configuration;
        private ISendMail _sendMail;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IConfiguration configuration, ITokenService tokenService, ISendMail sendMail, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _sendMail = sendMail;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("login/serviceValidate")]
        public async Task<string> ServiceValidate(string service, string ticket)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: AuthController\n** Accion: login/serviceValidate\n** GET");
            // Validate service ticket against CAS
            string response = await CasUtil.ConsumeCasValidate(_configuration["CasBaseUrl"], _configuration["CasValidateAction"], service, ticket);
            System.Diagnostics.Debug.WriteLine("** Response: " + response);
            if (CasUtil.CheckCasValidateFromResponse(response))
            {
                try
                {
                    // Get Username from CAS response
                    string email = CasUtil.GetUsernameFromResponse(response).Trim();
                    System.Diagnostics.Debug.WriteLine("** Email: " + email);
                    // Retrieve user and permissions from database
                    var user = _tokenService.GetUsuarioByEmail(email); //Obtengo el usuario
                    if (user == null)
                    {
                        //DEBO CREAR EL USUARIO
                        bool userCreate = await _tokenService.PostUserbyEmail(email);
                        if (!userCreate)
                        {
                            throw new BusinessException("No se pudo crear el usuario");
                        }
                        user = _tokenService.GetUsuarioByEmail(email);
                        _sendMail.WelcomeMail(user);//debo enviar el usuario nuevo
                    }
                    System.Diagnostics.Debug.WriteLine("** User[id]: " + user.Id);
                    var token = GenerateToken(user);
                    // Retrieve user's full name from GTSI API
                    // Build response
                    System.Diagnostics.Debug.WriteLine("** JWT: " + token);
                    return CasUtil.BuildCasValidateOkResponse(token);
                }
                catch(Exception e)
                {
                    return CasUtil.BuildCasValidateErrorResponse(e.Message);
                }
            }
            return response;
        }

        [Authorize]
        [HttpGet("logout")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteToken()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("*********\n** Controlador: AuthController\n** Accion: logout\n** GET");
                string email = ((ClaimsIdentity)User.Identity).FindFirst(x => x.Type == "correo").Value;
                var token = _httpContextAccessor.HttpContext.Request.Headers["authorization"].Single().Split(" ").Last();
                if (!_tokenService.TokenValid(token))
                {
                    return Unauthorized();
                }
                var flag = await _tokenService.EliminarToken(token, email);
                return Ok(flag);
            }
            catch
            {
                return Unauthorized();
            }
        }


        protected string GenerateToken(AuthUsuarios user)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var sigCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sigCredentials);
            var jsonPermisos = _unitOfWork.AuthUsuarioRepository.GetIdRol_Usuario(user).ToString(); //Cambiar, ir al Service del token y ahi llamar al metodo

            //Claim
            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
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
                DateTime.Now.AddMinutes(180)
            );

            //Tokens
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
