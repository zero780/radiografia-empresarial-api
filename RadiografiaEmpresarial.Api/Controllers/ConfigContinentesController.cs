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
    public class ConfigContinentesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConfigContinentesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ContinentesController>
        [HttpGet]
        public IActionResult Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: ContinentesController\n** Accion: /\n** GET");
            var cont = _unitOfWork.ContinentesRepository.GetAll();
            var response = new ApiResponse<IEnumerable<ConfigContinentes>>(cont);
            return Ok(response);
        }
    }
}
