using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
        }

        public AuthUsuarios GetUsuario(string nom)
        {
            IEnumerable<AuthUsuarios> usuarios = _unitOfWork.AuthUsuarioRepository.GetAll();
            AuthUsuarios user = usuarios.FirstOrDefault(x => x.Nombre.ToLower() == nom.ToLower());
            return user;
        }

        public AuthUsuarios GetUsuarioByEmail(string email)
        {
            IEnumerable<AuthUsuarios> usuarios = _unitOfWork.AuthUsuarioRepository.GetAll();
            AuthUsuarios user = usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            return user;
        }

        public async Task<bool> PostUserbyNombre(string nombre)
        {
            AuthUsuarios user = new AuthUsuarios();
            user.Nombre = nombre;
            user.Email = nombre + "@espol.edu.ec";
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await _unitOfWork.AuthUsuarioRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostUserbyEmail(string email)
        {
            AuthUsuarios user = new AuthUsuarios();
            user.Nombre = email;
            user.Email = email;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await _unitOfWork.AuthUsuarioRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarToken(string token, string email)
        {
            try
            {
                var user = GetUsuarioByEmail(email);
                AuthTokenUsuarios _token = new AuthTokenUsuarios
                {
                    IdUsuario = user.Id,
                    Token = token,
                    DeletedAt = DateTime.Now
                };

                await _unitOfWork.AuthTokenUsuariosRepository.Add(_token);
                await _unitOfWork.SaveChangesAsync();


                return true;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }

        public bool TokenValid(string token)
        {
            var _token = _unitOfWork.AuthTokenUsuariosRepository.GetToken(token);
            if(_token == null)
            {
                return true;
            }
            return false;
        }

    }
}
