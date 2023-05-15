using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IExcelService
    {
        Task<byte[]> ReporteOrganizacion();
        Task<byte[]> ReporteGrupoTrabajo();
    }
}
