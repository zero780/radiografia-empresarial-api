using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class AuthTokenUsuariosRepository : BaseRepository<AuthTokenUsuarios>, IAuthTokenUsuariosRepository
    {
        public AuthTokenUsuariosRepository(RadiografiaContext context) : base(context) { }

        public AuthTokenUsuarios GetToken(string token)
        {
            var _token = _entities.FirstOrDefault(x => x.Token.Contains(token));

            return _token;
        }
    }
}
