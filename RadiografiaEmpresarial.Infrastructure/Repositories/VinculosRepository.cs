using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class VinculosRepository : BaseRepository<CoreVinculos>, IVinculosRepository
    {
        public VinculosRepository(RadiografiaContext context) : base(context) { }
        public async Task<List<CoreVinculos>> GetVinculos()
        {
            var vinculosAll = await _entities.Include(x => x.CoreGrupos).ToListAsync();
            return vinculosAll;
        }
        public async Task<CoreVinculos> GetVinculo_ID(long id)
        {
            var vinculosAll = await _entities.Include(x => x.CoreGrupos).ToListAsync();
            var vinculo = vinculosAll.FirstOrDefault(x => x.Id == id);
            return vinculo;
        }
    }
}
