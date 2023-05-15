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
    public class ConfigCantonesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfigCantonesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<CantonesController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: CantonesController\n** Accion: /\n** GET");
            var cant = _unitOfWork.CantonesRepository.GetAll();
            var response = new ApiResponse<IEnumerable<ConfigCantones>>(cant);
            return Ok(response);
        }
    }
}
