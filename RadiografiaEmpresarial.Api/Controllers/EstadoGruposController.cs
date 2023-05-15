using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EstadoGruposController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EstadoGruposController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<EstadoGruposController>
        [HttpGet]
        public IActionResult Get()
        {
            var est = _unitOfWork.EstadoGrupoRepository.GetAll();
            var response = new ApiResponse<IEnumerable<EstadoGrupos>>(est);
            return Ok(response);
        }

        // GET api/<EstadoGruposController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var est = await _unitOfWork.EstadoGrupoRepository.GetById(id);
            var response = new ApiResponse<EstadoGrupos>(est);
            return Ok(response);
        }

        // POST api/<EstadoGruposController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EstadoGrupos estadosGr)
        {
            await _unitOfWork.EstadoGrupoRepository.Add(estadosGr);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<EstadoGrupos>(estadosGr);
            return Ok(response);
        }

        // PUT api/<EstadoGruposController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] EstadoGrupos estadosGr)
        {
            var currentEst = await _unitOfWork.EstadoGrupoRepository.GetById(id);
            currentEst.Slug = estadosGr.Slug;
            currentEst.Nombre = estadosGr.Nombre;
            currentEst.Descripcion = estadosGr.Descripcion;

            _unitOfWork.EstadoGrupoRepository.Update(currentEst);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<EstadoGrupos>(currentEst);
            return Ok(response);
        }

        // DELETE api/<EstadoGruposController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var vinc = await _unitOfWork.EstadoGrupoRepository.GetById(id);
            var response = new ApiResponse<EstadoGrupos>(vinc);
            await _unitOfWork.EstadoGrupoRepository.Delete(id);
            return Ok(response);
        }
    }
}
