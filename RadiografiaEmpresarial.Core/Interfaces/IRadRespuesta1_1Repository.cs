using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IRadRespuesta1_1Repository : IRepository<RadRespuestas11>
    {
        IEnumerable<object> GetRespuesta1_1ForReporte();
    }
}
