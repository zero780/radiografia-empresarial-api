using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IUsuarioRepository : IRepository<AuthUsuarios>
    {
        Task<AuthUsuarios> GetUsuariosbyEmailRol(string nomUser, long idRol);
        Task<AuthUsuarios> GetUsuariosconPermisosORG(string nomUser);

        string GetIdRol_Usuario(AuthUsuarios user);
        Task<bool> isAdmin(string nomUser);

        object GetUsuarioandRol(long id);
    }
}
