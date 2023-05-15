using AutoMapper;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Exceptions;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Services
{
    public class GruposTrabajoService : IGruposTrabajoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ISendMail _sendMail;
        private readonly IMapper _mapper;

        public GruposTrabajoService(IUnitOfWork unitOfWork, ISendMail sendMail, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _sendMail = sendMail;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<object>> GetGruposTrabajo()
        {
            return await _unitOfWork.GrupostrabajoRepository.GetGruposTrabajo();
        }

        public async Task<object> GetGrupoTrabajo(long id)
        {
            return await _unitOfWork.GrupostrabajoRepository.GetGrupos(id);
        }

        public async Task<AuthUsuarios> HasPermissions(string nom, long idRol)
        {
            var user = await _unitOfWork.AuthUsuarioRepository.GetUsuariosbyEmailRol(nom, idRol);

            return user;
            
        }


        public IEnumerable<object> GetGrupos(string nom,long idEstado)
        {
            var users = _unitOfWork.AuthUsuarioRepository.GetAll();
            var user = users.FirstOrDefault(x => x.Nombre.ToLower() == nom.ToLower());
            if (user == null)
            {
                return null;
            }
            var grupo = _unitOfWork.GrupostrabajoRepository.GetGruposTrabajoByUserId(user.Id, idEstado);
            return grupo;

        }

        public IEnumerable<object> GetGruposActivos(string nom, long estadoId)
        {
            var grupo =   GetGrupos(nom,estadoId);
            return grupo;

        }

        public IEnumerable<object> GetGruposPendientes(string nom, long estadoId)
        {
            var grupo = GetGrupos(nom, estadoId);
            return grupo;

        }

        public IEnumerable<object> GetGruposRechazados(string nom, long estadoId)
        {
            var grupo = GetGrupos(nom, estadoId);
            return grupo;

        }

        public IEnumerable<object> GetGruposFinalizados(string nom, long estadoId)
        {
            var grupo = GetGrupos(nom, estadoId);
            return grupo;

        }

        public IEnumerable<object> GetGrupo_UserId_byEstado(long UserId, long estadoId)
        {

            var grupo =  _unitOfWork.GrupostrabajoRepository.GetGruposTrabajoByUserId(UserId, estadoId);//Supervisores
            return grupo;

        }

        public IEnumerable<CoreGrupos> GetGrupo_ForUser(string userName)
        {
            var users = _unitOfWork.AuthUsuarioRepository.GetAll();
            var user = users.FirstOrDefault(x => x.Nombre.ToLower() == userName.ToLower());
            if (user == null)
            {
                throw new BusinessException("User doesn't exist");
            }
            var grupo = _unitOfWork.GrupostrabajoRepository.GetGruposTrabajo_ForUserID(user.Id);
            return grupo;
        }

        public IEnumerable<CoreGrupos> GetGrupo_ForUserID(long userID)
        {
            var grupo = _unitOfWork.GrupostrabajoRepository.GetGruposTrabajo_ForUserID(userID);
            return grupo;
        }

        public async Task<CoreGrupos> UpdateEstadoGrupo( long id, string estado)
        {
            var grupo = await _unitOfWork.GrupostrabajoRepository.GetById(id);
            if(grupo == null)
                throw new BusinessException("Group doesn't exist");
            switch (estado.ToLower())
            {
                case "approved":
                    grupo.IdEstado = 2;
                    break;
                case "denied":
                    grupo.IdEstado = 3;
                    break;
                case "closed":
                    grupo.IdEstado = 4;
                    break;
                default:
                    grupo.IdEstado = 1;
                    break;
            }
            _unitOfWork.GrupostrabajoRepository.Update(grupo);
            await _unitOfWork.SaveChangesAsync();
            return grupo;

        }

        public async Task<IEnumerable<CoreGrIntegrantes>> GetGrupoTrabajoByIntegranteId(long UserId)
        {

            return await _unitOfWork.GruposIntegranteRepository.GetGrupoIntegranteByUser(UserId);//Supervisores
        }


        public async Task<CoreGrupos> InsertGrupoTrabajo(GrupoTrabajoPersonalizado gt, AuthUsuarios user)
        {

            CoreGrupos grupoNuevo = new CoreGrupos();

            //long orgID = _unitOfWork.OrganizacionesRepository.GetAll().FirstOrDefault(x => x.Nombre.ToLower() == gt.Organizacion.ToLower()).Id;
            CoreOrganizaciones organizacion = _unitOfWork.OrganizacionesRepository.getOrganizacion(gt.Organizacion);
            if(organizacion == null)
            {
                return null;
            }

            long orgID = _unitOfWork.OrganizacionesRepository.getOrganizacion(gt.Organizacion).Id;
            long vincID = _unitOfWork.VinculosRepository.GetAll().FirstOrDefault(x => x.Slug.ToLower() == gt.Vinculo.ToLower()).Id;
            
            IEnumerable<AuthUsuarioTipoDTO> integrantes = gt.Integrantes.AsEnumerable();
            var usuarios = _unitOfWork.AuthUsuarioRepository.GetAll();

            
            //Creamos el Grupo de Trabajo(Falta Validaciones)
            grupoNuevo.IdEstado = 1;
            grupoNuevo.IdOrganizacion = orgID;
            grupoNuevo.IdVinculo = vincID;
            grupoNuevo.IdSupervisador = user.Id;
            grupoNuevo.MotivoRespuesta = gt.MotivoAceptacion;
            grupoNuevo.MotivoSolicitud = gt.MotivoCreacion;
            grupoNuevo.CreatedAt = DateTime.UtcNow;
            grupoNuevo.CreatedBy = user.Id;
            await _unitOfWork.GrupostrabajoRepository.Add(grupoNuevo);
            await _unitOfWork.SaveChangesAsync();

            //obtener el id del nuevo grupo
            long idGrupoNuevo = _unitOfWork.GrupostrabajoRepository.GetAll().FirstOrDefault(x => x.CreatedAt == grupoNuevo.CreatedAt).Id;

            //Creamos los Usuarios de los integrantes si es que no existen
            foreach (var integ in integrantes)
            {
                AuthUsuarios u = usuarios.FirstOrDefault(x => x.Email.ToLower() == integ.mail.ToLower());
                
                //Creamos Grupos de trabajo de los Integrantes
                CoreGrIntegrantes grIntegrantes = new CoreGrIntegrantes();

                grIntegrantes.IdGrupo = idGrupoNuevo;
                grIntegrantes.CreatedAt = DateTime.UtcNow;
                grIntegrantes.CreatedBy = user.Id;

                if ( u == null)
                {
                    //Creamos Usuario Nuevo
                    AuthUsuarios usuarioNuevo = new AuthUsuarios();
                    usuarioNuevo.Email = integ.mail;
                    usuarioNuevo.Nombre = integ.name;
                    usuarioNuevo.Extra = "Creado por " + user.Email;
                    //var integranteDTO = _mapper.Map<AuthUsuarios>(integ);
                    await _unitOfWork.AuthUsuarioRepository.Add(usuarioNuevo); //Debe enviar correo
                    await _unitOfWork.SaveChangesAsync();
                    u = usuarios.FirstOrDefault(x => x.Email.ToLower() == integ.mail.ToLower());
                    _sendMail.WelcomeMail(u);
                }
                
                if(integ.tipo.ToLower().Equals("Líder de grupo".ToLower()))
                {
                    grIntegrantes.IdTipo = 1;
                }
                else
                {
                    grIntegrantes.IdTipo = 2;
                }
                
                grIntegrantes.IdUsuario = u.Id;
                await _unitOfWork.GruposIntegranteRepository.Add(grIntegrantes);
                await _unitOfWork.SaveChangesAsync();
                _sendMail.WelcomeToGroupMail(u); //mensaje de agregado a un grupo

            }

            return grupoNuevo;
        }

        public async Task<bool> UpdateGrupoTrabajo(CoreGruposDTO gt, AuthUsuarios user)
        {
            var grupo = await _unitOfWork.GrupostrabajoRepository.GetById(gt.Id);
            
            if(grupo == null)
            {
                throw new BusinessException("Error, no existe grupo de trabajo");
            }

            
            if(gt.IdEstado != null )
            {
                grupo.IdEstado = (long)gt.IdEstado;
            }
            if(gt.IdOrganizacion != null)
            {
                grupo.IdOrganizacion = (long)gt.IdOrganizacion;
            }
            if(gt.IdSupervisador != null)
            {
                if (user.Id != grupo.IdSupervisador)
                {
                    throw new BusinessException("El Supervisor no es el encargado del grupo");
                }
                grupo.IdSupervisador = (long)gt.IdSupervisador;
            }
            if(gt.IdVinculo != null)
            {
                grupo.IdVinculo = (long)gt.IdVinculo;
            }
            if(gt.MotivoRespuesta != null)
            {
                grupo.MotivoRespuesta = gt.MotivoRespuesta;
            }
            if(gt.MotivoSolicitud != null)
            {
                grupo.MotivoSolicitud = gt.MotivoSolicitud;
            }
            grupo.UpdatedAt = DateTime.Now;
            grupo.UpdatedBy = user.Id;

            _unitOfWork.GrupostrabajoRepository.Update(grupo);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGrupoTrabajo(long id, AuthUsuarios user)
        {
            /*
            var grupo = await GetGrupoTrabajo(id);
            if(grupo == null)
            {
                throw new BusinessException("Grupo de Trabajo no existen");
            }
            if(grupo.IdSupervisador != user.Id)
            {
                throw new BusinessException("Supervisor no es el encargado del Grupo de Trabajo");
            }
            grupo.DeletedAt = DateTime.Now;
            grupo.DeletedBy = user.Id;
            await _unitOfWork.SaveChangesAsync();*/
            return true;
        }
    }
}
