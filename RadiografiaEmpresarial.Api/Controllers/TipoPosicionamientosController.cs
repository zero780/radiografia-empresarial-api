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
    public class TipoPosicionamientosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoPosicionamientosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<PaisesController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: Posicionamientos\n** Accion: /\n** GET");
            var posic = _unitOfWork.TipoPosicionamientosRepository.GetAll();
            var response = new ApiResponse<IEnumerable<TipoPosicionamientos>>(posic);
            return Ok(response);
        }
    }
}

