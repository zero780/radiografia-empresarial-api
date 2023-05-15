using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadiografiaEmpresarial.Api.Responses;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RadiografiaEmpresarial.Api.Controllers
{
    [Authorize]
    [Route("api/vinculos")]
    [ApiController]
    public class VinculosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public VinculosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: VinculosController\n** Accion: /\n** GET");
            var vinc = await _unitOfWork.VinculosRepository.GetVinculos();
            var response = new ApiResponse<List<CoreVinculos>>(vinc);
            return Ok(response);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: VinculosController\n** Accion: /{id}\n** GET\n** Id: " + id);
            var vinc = await _unitOfWork.VinculosRepository.GetVinculo_ID(id);
            var response = new ApiResponse<CoreVinculos>(vinc);
            return Ok(response);

        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CoreVinculos vinculos)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: VinculosController\n** Accion: /\n** POST");
            vinculos.Slug = SlugUtil.Generate(vinculos.Nombre);
            vinculos.CreatedAt = DateTime.Now;
            vinculos.UpdatedAt = DateTime.Now;
            await _unitOfWork.VinculosRepository.Add(vinculos);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<CoreVinculos>(vinculos);
            return Ok(response);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CoreVinculos vinculos)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: VinculosController\n** Accion: /{id}\n** PUT\n** Id: " + id);
            var currentVinc = await _unitOfWork.VinculosRepository.GetById(id);
            currentVinc.Slug = vinculos.Slug;
            currentVinc.Nombre = vinculos.Nombre;
            currentVinc.Descripcion = vinculos.Descripcion;
            currentVinc.UpdatedAt = DateTime.Now;

            _unitOfWork.VinculosRepository.Update(currentVinc);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<CoreVinculos>(currentVinc);
            return Ok(response);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            System.Diagnostics.Debug.WriteLine("*********\n** Controlador: VinculosController\n** Accion: /{id}\n** DELETE\n** Id: " + id);
            var vinc = await _unitOfWork.VinculosRepository.GetById(id);
            var response = new ApiResponse<CoreVinculos>(vinc);
            await _unitOfWork.VinculosRepository.Delete(id);
            return Ok(response);
        }
    }
}
