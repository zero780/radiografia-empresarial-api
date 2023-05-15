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
    public class TipoImportanciasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoImportanciasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<PaisesController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: CPCS\n** Accion: /\n** GET");
            var import = _unitOfWork.TipoImportanciasRepository.GetAll();
            var response = new ApiResponse<IEnumerable<TipoImportancias>>(import);
            return Ok(response);
        }
    }
}
