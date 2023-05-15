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
    public class TipoSeccionesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoSeccionesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<TipoSeccionesController>
        [HttpGet]
        public IActionResult Get()
        {
            var secciones = _unitOfWork.TipoSeccionesRepository.GetAll();
            var response = new ApiResponse<IEnumerable<TipoSecciones>>(secciones);
            return Ok(response);
        }

        // GET api/<TipoSeccionesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var vinc = await _unitOfWork.TipoSeccionesRepository.GetById(id);
            var response = new ApiResponse<TipoSecciones>(vinc);
            return Ok(response);
        }

        // POST api/<TipoSeccionesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoSecciones secciones)
        {
            await _unitOfWork.TipoSeccionesRepository.Add(secciones);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<TipoSecciones>(secciones);
            return Ok(response);
        }

        // PUT api/<TipoSeccionesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] TipoSecciones seccion)
        {
            var currentSeccion = await _unitOfWork.TipoSeccionesRepository.GetById(id);
            currentSeccion.Slug = seccion.Slug;
            currentSeccion.Nombre = seccion.Nombre;
            currentSeccion.Componente = seccion.Componente;
            currentSeccion.Descripcion = seccion.Descripcion;
            currentSeccion.Orden = seccion.Orden;
            currentSeccion.CreatedAt = seccion.CreatedAt;

            _unitOfWork.TipoSeccionesRepository.Update(currentSeccion);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<TipoSecciones>(currentSeccion);
            return Ok(response);
        }

        // DELETE api/<TipoSeccionesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var seccion = await _unitOfWork.TipoSeccionesRepository.GetById(id);
            var response = new ApiResponse<TipoSecciones>(seccion);
            await _unitOfWork.TipoSeccionesRepository.Delete(id);
            return Ok(response);
        }
    }
}
