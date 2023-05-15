using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TipoFrecuenciasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoFrecuenciasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<PaisesController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: Frecuencias\n** Accion: /\n** GET");
            var frec = _unitOfWork.TipoFrecuenciasRepository.GetAll();
            var response = new ApiResponse<IEnumerable<Core.Entities.TipoFrecuencias>>(frec);
            return Ok(response);
        }
    }
}
