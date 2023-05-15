using Newtonsoft.Json;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Services
{
    public class ReportesService : IReportesService
    {
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public ReportesService(ITokenService tokenService, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsPermitted(string token, long idRol, string email)
        {
            if (!_tokenService.TokenValid(token))
            {
                return false;
            }

            var user = await _unitOfWork.AuthUsuarioRepository.GetUsuariosbyEmailRol(email, idRol);

            if(user == null)
            {
                return false;
            }

            return true;

        }

        public IEnumerable<TipoReportes> GetReportes()
        {
            return _unitOfWork.TipoReportesRepository.GetAll();
        }

        public Dictionary<string,object> CreateReport(string slug, string param)
        {
            string consulta;
            object reporte = null;
            //string jsonVariables;

            /*
            if (param == null)
            {
                //Hacer filtros
            }*/

            switch (slug)
            {
                case "reportes-01":

                    reporte = _unitOfWork.RadiografiasRepository.GetRadiografiaForReporte();
                    break;

                case "reportes-02":
                    reporte = _unitOfWork.OrganizacionesRepository.GetOrganizacionForReporte();
                    break;

                case "reportes-03":
                    reporte = _unitOfWork.RadRespuesta1_1Repository.GetRespuesta1_1ForReporte();
                    break;

                default:
                    return null;
            }

            consulta = _unitOfWork.TipoReportesRepository.GetConsulta(slug);

            var config = _unitOfWork.TipoReportesRepository.GetConfig(slug);

            Dictionary<string, object> respuesta = new Dictionary<string, object>();
            respuesta.Add("dataset", reporte);
            respuesta.Add("columnas", consulta);
            respuesta.Add("config", config);

            return respuesta;

        }

    }
}
