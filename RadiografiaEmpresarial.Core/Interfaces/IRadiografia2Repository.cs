using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IRadiografia2Repository
    {
        IEnumerable<object> GetRadiografiaForReporte();

    }
}
