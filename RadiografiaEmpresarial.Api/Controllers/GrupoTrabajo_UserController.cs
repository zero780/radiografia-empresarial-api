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
    [Route("api/grupoTrabajo-User")]
    [ApiController]
    public class GrupoTrabajo_UserController : ControllerBase
    {
        private readonly IGruposTrabajoService _gruposTrabajoService;

        public GrupoTrabajo_UserController(IGruposTrabajoService gruposTrabajoService)
        {
            _gruposTrabajoService = gruposTrabajoService;
        }

        // GET: api/<GrupoTrabajo_UserController>
        /*[HttpGet]
        
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<GrupoTrabajo_UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetGrupoTrabajoBySupervisor(long id)
        {
            var grupo = _gruposTrabajoService.GetGrupo_UserId_byEstado(id,1);
            var response =  new ApiResponse<IEnumerable<object>>(grupo);

            return Ok(response);


        }

        /*
        // POST api/<GrupoTrabajo_UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GrupoTrabajo_UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GrupoTrabajo_UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
