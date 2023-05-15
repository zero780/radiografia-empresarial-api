using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Exceptions;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*
        public async Task<bool> postUserbyNombre(string nombre)
        {
            AuthUsuarios user = new AuthUsuarios();
            user.Nombre = nombre;
            user.Email = nombre + "@espol.edu.ec";
            user.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.AuthUsuarioRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }*/

        public async Task<AuthUsuarios> GetByUser(long idUser)
        {
            var user = await _unitOfWork.AuthUsuarioRepository.GetById(idUser);
            return user;

        }

        public object GetByUserandRol(long idUser)
        {
            var user = _unitOfWork.AuthUsuarioRepository.GetUsuarioandRol(idUser);
            return user;

        }

        public AuthUsuarios GetUsuarioByName(string nomUser)
        {
            IEnumerable<AuthUsuarios> usuarios = _unitOfWork.AuthUsuarioRepository.GetAll();
            AuthUsuarios userSesion = usuarios.FirstOrDefault(x => x.Nombre.ToLower() == nomUser.ToLower());
            return userSesion;
        }

        public AuthUsuarios GetUsuarioByEmail(string email)
        {
            IEnumerable<AuthUsuarios> usuarios = _unitOfWork.AuthUsuarioRepository.GetAll();
            AuthUsuarios userSesion = usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            return userSesion;
        }

        public IEnumerable<AuthUsuarios> GetUserAll()
        {
            return _unitOfWork.AuthUsuarioRepository.GetAll();
        }

        public async Task<AuthUsuarios> UpdateUser(AuthUsuarios user, string nomUser)
        {
            var userSesion = GetUsuarioByName(nomUser);
            if(userSesion == null)
            {
                throw new BusinessException("Usuario no habilitado");
            }

            if(userSesion.Id != user.Id)
            {
                throw new BusinessException("No puede actualizar otro Usuario");
            }

            var userUpdate = await GetByUser(user.Id);
            userUpdate.Nombre = user.Nombre;
            userUpdate.Email = user.Email;
            userUpdate.Extra = user.Extra;
            userUpdate.UpdatedAt = DateTime.Now;

            _unitOfWork.AuthUsuarioRepository.Update(userUpdate);
            await _unitOfWork.SaveChangesAsync();

            return userUpdate;
        }

        public async Task<bool> DeleteUser(long id, string nomUser)
        {
            var userSesion = GetUsuarioByName(nomUser);
            var userDelete = await GetByUser(id);

            if (userSesion == null)
            {
                throw new BusinessException("Usuario no habilitado");
            }

            if (userSesion.Id != userDelete.Id)
            {
                throw new BusinessException("No puede eliminar otro Usuario");
            }

            try
            {
                userDelete.DeletedAt = DateTime.Now;
                userDelete.DeletedBy = userSesion.Id;
                //await _unitOfWork.AuthUsuarioRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<bool> CreateUser(AuthUsuarios user)
        {
            var userFind = GetUsuarioByEmail(user.Email);
            if (userFind != null)
            {
                throw new BusinessException("Usuario con ese Email ya existe");
            }
            try
            {
                user.Nombre = user.Email;
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                await _unitOfWork.AuthUsuarioRepository.Add(user);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new BusinessException("Usuario no pudo ser creado");
            }
            
        }

        public async Task<AuthUsuarios> Update_RolUser(long idUser, string rolNew)
        {
            AuthUsuarios usuario = await _unitOfWork.AuthUsuarioRepository.GetById(idUser);
            if(usuario == null)
            {
                throw new BusinessException("User doesn't exist");
            }
            AuthRoUsuarios rolUser = _unitOfWork.AuthRoUsuariosRepository.GetAll().FirstOrDefault(x => x.IdUsuario == usuario.Id);
            long idRol = 0;
            switch (rolNew.ToLower())
            {
                case "administrador":
                    idRol = 1;
                    break;
                case "representante":
                    idRol = 2;
                    break;
                case "supervisor":
                    idRol = 3;
                    break;
                case "visualizador":
                    idRol = 4;
                    break;
                default:
                    throw new BusinessException("Rol doesn't exist");
            }
            if(rolUser == null)
            {
                AuthRoUsuarios _authRolUser = new AuthRoUsuarios();
                _authRolUser.IdRol = idRol;
                _authRolUser.IdUsuario = usuario.Id;
                _authRolUser.CreatedAt = DateTime.Now;
                await _unitOfWork.AuthRoUsuariosRepository.Add(_authRolUser);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                rolUser.IdRol = idRol;
                rolUser.UpdatedAt = DateTime.Now;
                _unitOfWork.AuthRoUsuariosRepository.Update(rolUser);
                await _unitOfWork.SaveChangesAsync();
            }

            return usuario;
        }

    }
}
