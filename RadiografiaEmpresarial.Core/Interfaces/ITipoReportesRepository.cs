using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface ITipoReportesRepository : IRepository<TipoReportes>
    {
        string GetConsulta(string slug);
        object GetConfig(string slug);
    }
}
