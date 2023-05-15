using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRadiografiaRepository RadiografiasRepository { get; }
        IRadiografia2Repository Radiografias2Repository { get; }
        IGrupo_TrabajoRepository GrupostrabajoRepository { get; }
        IOrganizacionRepository OrganizacionesRepository { get; }
        IRepository<EstadoRadiografias> estadoRadiografiasRepository { get; }
        IGrupoIntegranteRepository GruposIntegranteRepository { get; }
        IVinculosRepository VinculosRepository { get; }
        IRepository<ConfigCantones> CantonesRepository { get; }
        IRepository<ConfigContinentes> ContinentesRepository { get; }
        IRepository<ConfigPaises> PaisesRepository { get; }
        IRepository<ConfigParroquias> ParroquiasRepository { get; }
        IRepository<ConfigProvincias> ProvinciasRepository { get; }
        IRepository<RadRadiografias> RadRadiografiasRepository { get; }

        IRepository<TipoCiius> TipoCiiusRepository { get; }
        IRepository<TipoClientes> TipoClientesRepository { get; }
        IRepository<TipoCpcs> TipoCpcsRepository { get; }
        IRepository<TipoFrecuencias> TipoFrecuenciasRepository { get; }
        IRepository<TipoImportancias> TipoImportanciasRepository { get; }
        IRepository<TipoJuridicas> TipoJuridicasRepository { get; }
        IRepository<TipoMercados> TipoMercadosRepository { get; }
        IRepository<TipoPosicionamientos> TipoPosicionamientosRepository { get; }
        IRepository<TipoSuministros> TipoSuministrosRepository { get; }
        IUsuarioRepository AuthUsuarioRepository { get; }
        IRepository<AuthRoUsuarios> AuthRoUsuariosRepository { get; }
        IRepository<EstadoGrupos> EstadoGrupoRepository { get; }
        IRepository<TipoSecciones> TipoSeccionesRepository { get; }
        IAuthTokenUsuariosRepository AuthTokenUsuariosRepository { get; }
        IRepository<AuthRoles> RolesRepository { get; }
        ITipoReportesRepository TipoReportesRepository { get; }
        IRadRespuesta1_1Repository RadRespuesta1_1Repository { get; }
        IRepository<RadRespuestas2A> RadRespuestas2ARepository { get; }
        IRepository<RadRespuestas2B1> RadRespuestas2B1Repository { get; }
        IRepository<RadRespuestas2B2> RadRespuestas2B2Repository { get; }
        IRepository<RadRespuestas2C> RadRespuestas2CRepository { get; }
        IRepository<RadRespuestas2D1> RadRespuestas2D1Repository { get; }
        IRepository<RadRespuestas2D2> RadRespuestas2D2Repository { get; }
        IRepository<RadRespuestas2E> RadRespuestas2ERepository { get; }
        IRepository<RadRespuestas2F1> RadRespuestas2F1Repository { get; }
        IRepository<RadRespuestas2F2> RadRespuestas2F2Repository { get; }
        IRepository<RadRespuestas2G> RadRespuestas2GRepository { get; }
        IRepository<RadRespuestas2H> RadRespuestas2HRepository { get; }

        //IRepository<juridico> VinculoRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();

    }
}
