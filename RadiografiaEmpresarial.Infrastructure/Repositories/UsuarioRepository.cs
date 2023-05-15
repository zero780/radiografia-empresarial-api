using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<AuthUsuarios>, IUsuarioRepository
    {
        public UsuarioRepository(RadiografiaContext context) : base(context) { }

        public async Task<AuthUsuarios> GetUsuariosbyEmailRol(string nomUser, long idRol)
        {
            var user = await _entities.Include(x => x.AuthRoUsuariosIdUsuarioNavigation).Where(x => x.AuthRoUsuariosIdUsuarioNavigation.Select(y => y.IdRol).Contains(idRol)).FirstOrDefaultAsync(x => x.Nombre.ToLower() == nomUser.ToLower());
            return user;
        }

        public async Task<AuthUsuarios> GetUsuariosconPermisosORG(string nomUser)
        {
            var userAdm = await _entities.Include(x => x.AuthRoUsuariosIdUsuarioNavigation).Where(x => x.AuthRoUsuariosIdUsuarioNavigation.Select(y => y.IdRol).Contains(1)).FirstOrDefaultAsync(x => x.Nombre.ToLower() == nomUser.ToLower());
            var userRep = await _entities.Include(x => x.AuthRoUsuariosIdUsuarioNavigation).Where(x => x.AuthRoUsuariosIdUsuarioNavigation.Select(y => y.IdRol).Contains(2)).FirstOrDefaultAsync(x => x.Nombre.ToLower() == nomUser.ToLower());
            var userSup = await _entities.Include(x => x.AuthRoUsuariosIdUsuarioNavigation).Where(x => x.AuthRoUsuariosIdUsuarioNavigation.Select(y => y.IdRol).Contains(3)).FirstOrDefaultAsync(x => x.Nombre.ToLower() == nomUser.ToLower());
            if (userAdm == null && userRep == null && userSup == null )
            {
                return null;
            }
            var user = await _entities.FirstOrDefaultAsync(x => x.Nombre.ToLower() == nomUser.ToLower());
            return user;
        }

        public string GetIdRol_Usuario(AuthUsuarios user)
        {
            var ModelandAccion = _entities.Include(x => x.AuthRoUsuariosIdUsuarioNavigation).Where(x => x.Id == user.Id).Select(x => new
            {
                Permisos = x.AuthRoUsuariosIdUsuarioNavigation.Select(
                    y => y.IdRolNavigation.AuthRoPermisos.Select(z => new { model = z.IdPermisoNavigation.Modelo, action = z.IdPermisoNavigation.Accion })
                )
            }).FirstOrDefault().Permisos.ToList();

            string result = JsonConvert.SerializeObject(ModelandAccion);

            return result;

        }

        public async Task<bool> isAdmin(string nomUser)
        {
            var user = await _entities.Include(x => x.AuthRoUsuariosIdUsuarioNavigation).Where(x => x.AuthRoUsuariosIdUsuarioNavigation.Select(y => y.IdRol).Contains(1)).FirstOrDefaultAsync(x => x.Nombre.ToLower() == nomUser.ToLower());
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public object GetUsuarioandRol(long id)
        {
            var resp = _entities.Include(x => x.AuthRoUsuariosIdUsuarioNavigation).ThenInclude(z => z.IdRolNavigation).Where(x => x.Id == id).Select(x => new { x.Nombre, x.Email, x.Extra, x.CreatedAt, x.UpdatedAt, x.DeletedAt, x.DeletedBy, roles = x.AuthRoUsuariosIdUsuarioNavigation.Select(y => new { y.IdRol,y.IdRolNavigation.Nombre }) }).FirstOrDefault(); ;

            return resp;
        }

    }
}
