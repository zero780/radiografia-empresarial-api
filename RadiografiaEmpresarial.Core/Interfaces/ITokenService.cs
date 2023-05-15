using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface ITokenService
    {
        AuthUsuarios GetUsuario(string nom);
        AuthUsuarios GetUsuarioByEmail(string email);
        Task<bool> PostUserbyNombre(string nombre);
        Task<bool> PostUserbyEmail(string email);
        //string GenerateToken();
        Task<bool> EliminarToken(string token, string nomUser);
        bool TokenValid(string token);
    }
}
