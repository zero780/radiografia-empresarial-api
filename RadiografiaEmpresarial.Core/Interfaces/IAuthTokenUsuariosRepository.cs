using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IAuthTokenUsuariosRepository : IRepository<AuthTokenUsuarios>
    {
        AuthTokenUsuarios GetToken(string token);
    }
}
