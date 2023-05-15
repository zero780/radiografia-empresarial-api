using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IUsuarioService
    {
        //Task<bool> postUserbyNombre(string nombre);

        Task<AuthUsuarios> GetByUser(long idUser);
        AuthUsuarios GetUsuarioByName(string nombre);
        AuthUsuarios GetUsuarioByEmail(string email);
        IEnumerable<AuthUsuarios> GetUserAll();
        Task<AuthUsuarios> UpdateUser(AuthUsuarios user, string nomUser);
        Task<bool> DeleteUser(long id, string userId);
        Task<bool> CreateUser(AuthUsuarios user);
        object GetByUserandRol(long idUser);
        Task<AuthUsuarios> Update_RolUser(long idUser, string rolNew);
    }
}
