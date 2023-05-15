using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class GrupoIntegranteRepository : BaseRepository<CoreGrIntegrantes>, IGrupoIntegranteRepository
    {
        public GrupoIntegranteRepository(RadiografiaContext context) : base(context){}
        public async Task<IEnumerable<CoreGrIntegrantes>> GetGrupoIntegranteByUser(long Userid)
        {
            return await _entities.Include(x => x.IdGrupoNavigation).Where(x => x.IdUsuario== Userid).ToListAsync();
        }

    }
}
