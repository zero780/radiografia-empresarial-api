using Microsoft.EntityFrameworkCore;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class GrupoTrabajoRepository : BaseRepository<CoreGrupos>, IGrupo_TrabajoRepository
    {
        public GrupoTrabajoRepository(RadiografiaContext context) : base(context){}

        public async Task<IEnumerable<object>> GetGruposTrabajo()
        {
            //var grupoInteg = _entities.Include(x => x.CoreGrIntegrantes).Select(x => new { x.CoreGrIntegrantes }).AsEnumerable();
            //var grupoFirst = grupoInteg.FirstOrDefault();
            //var cantInteg = grupoFirst != null ? grupoFirst.CoreGrIntegrantes.Count() : 0;

            var grupoTrabajo = await  _entities.Include(x => x.IdOrganizacionNavigation).Include(x => x.IdVinculoNavigation).Include(x => x.IdEstadoNavigation).Include(x => x.IdSupervisadorNavigation).Include(x => x.CoreGrIntegrantes).ThenInclude(y => y.IdUsuarioNavigation).Select(z => new { z, Integrantes = z.CoreGrIntegrantes.Select(x => x.IdUsuarioNavigation).Select(x => new { x.Email, x.Nombre }) })
                .Select(x => new { x.z.Id,idestado = x.z.IdEstadoNavigation.Id, estado = x.z.IdEstadoNavigation.Nombre, idorganizacion = x.z.IdOrganizacionNavigation.Id, organizacion = x.z.IdOrganizacionNavigation.Nombre, idvinculo = x.z.IdVinculoNavigation.Id, vinculo = x.z.IdVinculoNavigation.Nombre, idsupervisor = x.z.IdSupervisadorNavigation.Id, supervisor = x.z.IdSupervisadorNavigation.Nombre, x.z.MotivoSolicitud, x.z.MotivoRespuesta, x.z.CreatedAt, x.z.UpdatedAt, x.z.DeletedAt, cantidadIntegrantes = x.Integrantes.Count(), integrantes = x.Integrantes }).ToListAsync();

            return grupoTrabajo;
        }

        public async Task<object> GetGrupos(long id)
        {
            //var grupoInteg = _entities.Include(x => x.CoreGrIntegrantes).Select(x => new { x.CoreGrIntegrantes }).AsEnumerable();
            //var cantInteg = grupoInteg.First().CoreGrIntegrantes.Count();

            var grupoTrabajo = await _entities.Include(x => x.IdOrganizacionNavigation).Include(x => x.IdVinculoNavigation).Include(x => x.IdEstadoNavigation).Include(x => x.IdSupervisadorNavigation).Include(x => x.CoreGrIntegrantes).ThenInclude(y => y.IdUsuarioNavigation).Select(z => new { z, Integrantes = z.CoreGrIntegrantes.Select(x => new{ x.IdTipoNavigation.Slug,x.IdUsuarioNavigation}).Select(x => new { tipo = x.Slug,x.IdUsuarioNavigation.Email, x.IdUsuarioNavigation.Nombre }) })
                .Select(x => new { x.z.Id,idestado = x.z.IdEstadoNavigation.Id, estado = x.z.IdEstadoNavigation.Nombre, idorganizacion = x.z.IdOrganizacionNavigation.Id, organizacion = x.z.IdOrganizacionNavigation.Nombre, idvinculo = x.z.IdVinculoNavigation.Id, vinculo = x.z.IdVinculoNavigation.Nombre, idsupervisor = x.z.IdSupervisadorNavigation.Id, supervisor = x.z.IdSupervisadorNavigation.Nombre, x.z.MotivoSolicitud, x.z.MotivoRespuesta, x.z.CreatedAt, x.z.UpdatedAt, x.z.DeletedAt, cantidadIntegrantes = x.Integrantes.Count(), integrantes = x.Integrantes }).FirstOrDefaultAsync(w => w.Id == id);

            return grupoTrabajo;
        }

        public IEnumerable<object> GetGruposTrabajoByUserId(long userId, long idEstado)
        {
            //var grupoInteg =  _entities.Include(x => x.CoreGrIntegrantes).Select(x => new { x.CoreGrIntegrantes }).AsEnumerable();
            //var cantInteg = grupoInteg.First().CoreGrIntegrantes.Count();

            var grupoTrabajo =  _entities.Include(x => x.IdOrganizacionNavigation).Include(x => x.IdVinculoNavigation).Include(x => x.IdEstadoNavigation).Include(x => x.IdSupervisadorNavigation).Include(x => x.CoreGrIntegrantes).ThenInclude(y => y.IdUsuarioNavigation).Select(z=> new { z, Integrantes = z.CoreGrIntegrantes.Select(x => x.IdUsuarioNavigation).Select(x => new { x.Email,x.Nombre })}).
                Where(x => (x.z.CoreGrIntegrantes.Select(y => y.IdUsuario).Contains(userId) || x.z.IdSupervisador == userId) && x.z.IdEstado == idEstado)
                .Select(x=> new { idestado = x.z.IdEstadoNavigation.Id, estado= x.z.IdEstadoNavigation.Nombre, idorganizacion = x.z.IdOrganizacionNavigation.Id,organizacion = x.z.IdOrganizacionNavigation.Nombre, idvinculo = x.z.IdVinculoNavigation.Id, vinculo = x.z.IdVinculoNavigation.Nombre, idsupervisor = x.z.IdSupervisadorNavigation.Id, supervisor = x.z.IdSupervisadorNavigation.Nombre, x.z.MotivoSolicitud, x.z.MotivoRespuesta, x.z.CreatedAt, x.z.UpdatedAt, x.z.DeletedAt, cantidadIntegrantes = x.Integrantes.Count(), integrantes = x.Integrantes }).AsEnumerable();

            return grupoTrabajo;

        }

        public IEnumerable<CoreGrupos> GetGruposTrabajo_ForUserID(long userID)
        {
            var grupoTrabajo = _entities.Include(x => x.CoreGrIntegrantes).ThenInclude(z => z.IdUsuarioNavigation).Where( y => y.CoreGrIntegrantes.Select(x=>x.IdUsuario).Contains(userID) || y.IdSupervisador == userID);
            return grupoTrabajo;
        }

        public async Task<List<CoreGrupos>> GetAllComplet()
        {
            return await _entities.Include(x => x.IdEstadoNavigation).Include(x => x.IdOrganizacionNavigation).Include(x => x.IdSupervisadorNavigation).Include(x => x.IdVinculoNavigation).ToListAsync();
        }

    }
}
