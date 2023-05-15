using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IVinculosRepository : IRepository<CoreVinculos>
    {
        Task<List<CoreVinculos>> GetVinculos();
        Task<CoreVinculos> GetVinculo_ID(long id);
    }
}
