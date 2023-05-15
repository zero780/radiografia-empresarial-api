using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RadiografiaContext _context;
        private readonly IRadiografiaRepository _radiografiasRepository;
        private readonly IRadiografia2Repository _radiografias2Repository;
        private readonly IGrupo_TrabajoRepository _gruposTrabajoRepository;
        private readonly IOrganizacionRepository _organizacionesRepository;
        private readonly IRepository<EstadoRadiografias> _estadoRadiografiasRepository;
        private readonly IGrupoIntegranteRepository _grupoIntegranteRepository;
        private readonly IVinculosRepository _vinculosRepository;
        //nuevos Interfaces 
        private readonly IRepository<ConfigCantones> _cantonesRepository;
        private readonly IRepository<ConfigContinentes> _continentesRepository;
        private readonly IRepository<ConfigPaises> _paisesRepository;
        private readonly IRepository<ConfigParroquias> _parroquiasRepository;
        private readonly IRepository<ConfigProvincias> _provinciasRepository;
        private readonly IRepository<TipoCiius> _tipoCiiussRepository;
        private readonly IRepository<TipoClientes> _tipoClientesRepository;
        private readonly IRepository<TipoCpcs> _tipoCpcsRepository;
        private readonly IRepository<TipoFrecuencias> _tipoFrecuenciasRepository;
        private readonly IRepository<TipoImportancias> _tipoImportanciasRepository;
        private readonly IRepository<TipoJuridicas> _tipoJuridicasRepository;
        private readonly IRepository<TipoMercados> _tipoMercadosRepository;
        private readonly IRepository<TipoPosicionamientos> _tipoPosicionamientosRepository;
        private readonly IRepository<TipoSuministros> _tipoSuministrosRepository;
        private readonly IRepository<RadRadiografias> _radRadiografiasRepository;
        private readonly IRepository<RadRadiografias2> _radRadiografias2Repository;

        private readonly IUsuarioRepository _authUsuarioRepository;
        private readonly IRepository<AuthRoUsuarios> _authRoUsuariosRepository;
        private readonly IRepository<EstadoGrupos> _estadoGrupoRepository;
        private readonly IRepository<TipoSecciones> _tipoSeccionRepository;
        private readonly IAuthTokenUsuariosRepository _authTokenUsuariosRepository;
        private readonly IRepository<AuthRoles> _rolesRepository;
        private readonly ITipoReportesRepository _tipoReportesRepository;
        private readonly IRadRespuesta1_1Repository _radRespuesta1_1Repository;
        private readonly IRepository<RadRespuestas2A> _radRespuesta2ARepository;
        private readonly IRepository<RadRespuestas2B1> _radRespuesta2B1Repository;
        private readonly IRepository<RadRespuestas2B2> _radRespuesta2B2Repository;
        private readonly IRepository<RadRespuestas2C> _radRespuesta2CRepository;
        private readonly IRepository<RadRespuestas2D1> _radRespuesta2D1Repository;
        private readonly IRepository<RadRespuestas2D2> _radRespuesta2D2Repository;
        private readonly IRepository<RadRespuestas2E> _radRespuesta2ERepository;
        private readonly IRepository<RadRespuestas2F1> _radRespuesta2F1Repository;
        private readonly IRepository<RadRespuestas2F2> _radRespuesta2F2Repository;
        private readonly IRepository<RadRespuestas2G> _radRespuesta2GRepository;
        private readonly IRepository<RadRespuestas2H> _radRespuesta2HRepository;

        //private readonly IRepository<juridico> _vinculoRepository;

        public UnitOfWork(RadiografiaContext context)
        {
            _context = context;
        }

        public IRadRespuesta1_1Repository RadRespuesta1_1Repository => _radRespuesta1_1Repository ?? new RadRespuesta1_1Repository(_context);
        public IRadiografiaRepository RadiografiasRepository => _radiografiasRepository ?? new RadiografiasRepository(_context);
        public IRadiografia2Repository Radiografias2Repository => _radiografias2Repository ?? new Radiografias2Repository(_context);
        public IGrupo_TrabajoRepository GrupostrabajoRepository => _gruposTrabajoRepository ?? new GrupoTrabajoRepository(_context);

        public IOrganizacionRepository OrganizacionesRepository => _organizacionesRepository ?? new OrganizacionesRepository(_context);

        public IRepository<EstadoRadiografias> estadoRadiografiasRepository => _estadoRadiografiasRepository ?? new BaseRepository<EstadoRadiografias>(_context);

        public IGrupoIntegranteRepository GruposIntegranteRepository => _grupoIntegranteRepository ?? new GrupoIntegranteRepository(_context);

        public IVinculosRepository VinculosRepository => _vinculosRepository ?? new VinculosRepository(_context);

        public IUsuarioRepository AuthUsuarioRepository => _authUsuarioRepository ?? new UsuarioRepository(_context);

        public IRepository<AuthRoUsuarios> AuthRoUsuariosRepository => _authRoUsuariosRepository ?? new BaseRepository<AuthRoUsuarios>(_context);

        public IRepository<EstadoGrupos> EstadoGrupoRepository => _estadoGrupoRepository ?? new BaseRepository<EstadoGrupos>(_context);

        public IRepository<TipoSecciones> TipoSeccionesRepository => _tipoSeccionRepository ?? new BaseRepository<TipoSecciones>(_context);

        public IAuthTokenUsuariosRepository AuthTokenUsuariosRepository => _authTokenUsuariosRepository ?? new AuthTokenUsuariosRepository(_context);

        public IRepository<AuthRoles> RolesRepository => _rolesRepository ?? new BaseRepository<AuthRoles>(_context);

        public ITipoReportesRepository TipoReportesRepository => _tipoReportesRepository ?? new TipoReportesRepository(_context);
        public IRepository<RadRespuestas2A> RadRespuestas2ARepository => _radRespuesta2ARepository ?? new BaseRepository<RadRespuestas2A>(_context);
        public IRepository<RadRespuestas2B1> RadRespuestas2B1Repository => _radRespuesta2B1Repository ?? new BaseRepository<RadRespuestas2B1>(_context);
        public IRepository<RadRespuestas2B2> RadRespuestas2B2Repository => _radRespuesta2B2Repository ?? new BaseRepository<RadRespuestas2B2>(_context);
        public IRepository<RadRespuestas2C> RadRespuestas2CRepository => _radRespuesta2CRepository ?? new BaseRepository<RadRespuestas2C>(_context);
        public IRepository<RadRespuestas2D1> RadRespuestas2D1Repository => _radRespuesta2D1Repository ?? new BaseRepository<RadRespuestas2D1>(_context);
        public IRepository<RadRespuestas2D2> RadRespuestas2D2Repository => _radRespuesta2D2Repository ?? new BaseRepository<RadRespuestas2D2>(_context);
        public IRepository<RadRespuestas2E> RadRespuestas2ERepository => _radRespuesta2ERepository ?? new BaseRepository<RadRespuestas2E>(_context);
        public IRepository<RadRespuestas2F1> RadRespuestas2F1Repository => _radRespuesta2F1Repository ?? new BaseRepository<RadRespuestas2F1>(_context);
        public IRepository<RadRespuestas2F2> RadRespuestas2F2Repository => _radRespuesta2F2Repository ?? new BaseRepository<RadRespuestas2F2>(_context);
        public IRepository<RadRespuestas2G> RadRespuestas2GRepository => _radRespuesta2GRepository ?? new BaseRepository<RadRespuestas2G>(_context);
        public IRepository<RadRespuestas2H> RadRespuestas2HRepository => _radRespuesta2HRepository ?? new BaseRepository<RadRespuestas2H>(_context);

        public IRepository<ConfigCantones> CantonesRepository => _cantonesRepository ?? new BaseRepository<ConfigCantones>(_context);

        public IRepository<ConfigContinentes> ContinentesRepository => _continentesRepository ?? new BaseRepository<ConfigContinentes>(_context);

        public IRepository<ConfigPaises> PaisesRepository => _paisesRepository ?? new BaseRepository<ConfigPaises>(_context);

        public IRepository<ConfigParroquias> ParroquiasRepository => _parroquiasRepository ?? new BaseRepository<ConfigParroquias>(_context);

        public IRepository<ConfigProvincias> ProvinciasRepository => _provinciasRepository ?? new BaseRepository<ConfigProvincias>(_context);

        public IRepository<TipoCiius> TipoCiiusRepository => _tipoCiiussRepository ?? new BaseRepository<TipoCiius>(_context);

        public IRepository<TipoClientes> TipoClientesRepository => _tipoClientesRepository ?? new BaseRepository<TipoClientes>(_context);

        public IRepository<TipoCpcs> TipoCpcsRepository => _tipoCpcsRepository ?? new BaseRepository<TipoCpcs>(_context);

        public IRepository<TipoFrecuencias> TipoFrecuenciasRepository => _tipoFrecuenciasRepository ?? new BaseRepository<TipoFrecuencias>(_context);

        public IRepository<TipoImportancias> TipoImportanciasRepository => _tipoImportanciasRepository ?? new BaseRepository<TipoImportancias>(_context);

        public IRepository<TipoJuridicas> TipoJuridicasRepository => _tipoJuridicasRepository ?? new BaseRepository<TipoJuridicas>(_context);

        public IRepository<TipoMercados> TipoMercadosRepository => _tipoMercadosRepository ?? new BaseRepository<TipoMercados>(_context);

        public IRepository<TipoPosicionamientos> TipoPosicionamientosRepository => _tipoPosicionamientosRepository ?? new BaseRepository<TipoPosicionamientos>(_context);

        public IRepository<TipoSuministros> TipoSuministrosRepository => _tipoSuministrosRepository ?? new BaseRepository<TipoSuministros>(_context);

        public IRepository<RadRadiografias> RadRadiografiasRepository => _radRadiografiasRepository ?? new BaseRepository<RadRadiografias>(_context);

        

        //crear los nuevos repositorios
        //public IRepository<jurdico> VinculoRepository => _vinculoRepository ?? new BaseRepository<juridico>(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
