using AutoMapper;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using RadiografiaEmpresarial.Core.Exceptions;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Services
{
    public class RadiografiaService : IRadiografiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeccionRadiografia _seccionRadiografia;
        private readonly IMapper _mapper;

        public RadiografiaService(IUnitOfWork unitOfWork, ISeccionRadiografia seccionRadiografia, IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _seccionRadiografia = seccionRadiografia;
            _mapper = mapper;
        }

        public async Task<bool> DeleteRadiografia(long id)
        {
            await _unitOfWork.RadiografiasRepository.DeleteRadiografia (id);
            return true;
        }

        public async Task<RadRadiografias> GetRadiografia(long id)
        {
            return await _unitOfWork.RadiografiasRepository.GetRadiografia(id);
        }

        public IEnumerable<RadRadiografias> GetRadiografias()
        {
            return _unitOfWork.RadiografiasRepository.GetRadiografias();
        }

        public IEnumerable<object> GetRadiografias2(string query)
        {
            return _seccionRadiografia.radiografia_estado_organizacion(query);
        }

        public async Task InsertRadiografia(RadRadiografias radiografia)
        {
            
            var org = await _unitOfWork.OrganizacionesRepository.GetById(radiografia.IdOrganizacion);
            var estado = await _unitOfWork.estadoRadiografiasRepository.GetById((long) radiografia.IdEstado);

            //Validación que existan la Organización y el Estado.
            if (org == null || estado == null)
            {
                if(org == null && estado != null)
                {
                    throw new BusinessException("Organization doesn't exist");
                }
                if (estado == null && org != null)
                {
                    throw new BusinessException("Estado doesn't exist");
                }

                throw new BusinessException("Organization and Estado doesn't exist");
            }

            //Validación de Una radiografía por empresa
            if(org.Id == radiografia.IdOrganizacion)
            {
                throw new BusinessException("Radiografía ya existente para dicha organización");
            }

            await _unitOfWork.RadiografiasRepository.InsertRadiografia(radiografia);
            await _unitOfWork.SaveChangesAsync();
            //return radiografia;
        }

        public async Task<bool> UpdateRadiografia(RadRadiografias rad)
        {
            _unitOfWork.RadiografiasRepository.UpdateRadiografia(rad);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public IEnumerable<object> GetSecciones()
        {
            return _unitOfWork.TipoSeccionesRepository.GetAll().Select(x => new { x.Slug, x.Nombre, x.Descripcion, x.Componente, x.Url }).AsEnumerable();
        }

        public Dictionary<string,object> GetSecciones_Rad(string tabla, long idRad, long idGrupo)
        {
            string query = "Select * From " + tabla + " where id_radiografia =" + idRad + " and id_grupo =" + idGrupo;
            var resp = _seccionRadiografia.seccion1_1(query);
            string queryRadEmpresa = "Select * From " + tabla + " where id_radiografia =" + idRad + " and id_grupo is NULL";
            var lleno = _seccionRadiografia.seccion1_1Llenados(queryRadEmpresa);

            Dictionary<string, object> dicRespuesta = new Dictionary<string, object>();
            dicRespuesta.Add("radiografiaGrupo", resp);
            dicRespuesta.Add("camposLleno", lleno);

            return dicRespuesta;
        }

        public async Task<bool> InsertData_Radiografia_seccion1(RadRespuestas11 seccion1) 
        {
            RadRespuestas11 resp1_Global = null;
            var org_id = await _unitOfWork.OrganizacionesRepository.GetById(seccion1.IdOrganizacion);
            var rad_id = await _unitOfWork.RadiografiasRepository.GetRadiografia(seccion1.IdRadiografia);
            if (org_id == null || rad_id == null) 
            {
                if(org_id == null && rad_id == null)
                    throw new BusinessException("Radiografiía and Organization doesn't exist");
                else if(org_id == null)
                    throw new BusinessException("Organization doesn't exist");
                else
                    throw new BusinessException("Radiografia doesn't exist");
            }

            if (seccion1.IdGrupo != null) // Grupo de Trabajo Ingresa Registro
            {
                CoreGrupos gru_id = await _unitOfWork.GrupostrabajoRepository.GetById((long)seccion1.IdGrupo);
                if(gru_id == null)
                    throw new BusinessException("Grupo de Trabajo doesn't exist");

                //verificando si no existe un registro previo con mismos id
                resp1_Global = _unitOfWork.RadRespuesta1_1Repository.GetAll().FirstOrDefault(
                    x => x.IdGrupo == seccion1.IdGrupo && x.IdOrganizacion == seccion1.IdOrganizacion && x.IdRadiografia == seccion1.IdRadiografia
                ); //Obtenemos la sección1 de la radiografia General de la empresa
                
                if (resp1_Global != null)// Si no existe registro de seccion1 de la radiografia general
                {
                    //throw new BusinessException("ya existe");
                    seccion1.UpdatedAt = DateTime.Now;

                    try
                    {
                        _unitOfWork.RadRespuesta1_1Repository.Update(seccion1);
                        await _unitOfWork.SaveChangesAsync();
                        System.Diagnostics.Debug.WriteLine("*********\n** actualizado bien /\n** GET");

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                //throw new BusinessException("no ya existe");
                seccion1.CreatedAt = DateTime.Now;
                try
                {
                    await _unitOfWork.RadRespuesta1_1Repository.Add(seccion1);
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else //Cuando el Supervisor Ingresa los Registros
            {
                resp1_Global = _unitOfWork.RadRespuesta1_1Repository.GetAll().FirstOrDefault(
                    x => x.IdGrupo == null && x.IdOrganizacion == seccion1.IdOrganizacion && x.IdEstado == 2); //Obtenemos la sección1 de la radiografia General de la empresa
                if (resp1_Global == null) //Si no existe registro de seccion1 de la radiografia general
                {
                    seccion1.CreatedAt = DateTime.Now;
                    try
                    {
                        await _unitOfWork.RadRespuesta1_1Repository.Add(seccion1);
                        await _unitOfWork.SaveChangesAsync();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else //Existe seccion1 de la radiografia general
                {
                    if (seccion1.NombreComercial.Length > 0)
                        resp1_Global.NombreComercial = seccion1.NombreComercial;
                    if (seccion1.RazonSocial.Length > 0)
                        resp1_Global.RazonSocial = seccion1.RazonSocial;
                    if (seccion1.RepresentanteLegal.Length > 0)
                        resp1_Global.RepresentanteLegal = seccion1.RepresentanteLegal;
                    if (seccion1.IdTipoIdentificacion != null)
                        resp1_Global.IdTipoIdentificacion = seccion1.IdTipoIdentificacion;
                    if (seccion1.Identificacion.Length > 0)
                        resp1_Global.Identificacion = seccion1.Identificacion;
                    if (seccion1.Gerente.Length > 0)
                        resp1_Global.Gerente = seccion1.Gerente;
                    if (seccion1.IdProvincia != null)
                        resp1_Global.IdProvincia = seccion1.IdProvincia;
                    if (seccion1.IdCanton != null)
                        resp1_Global.IdCanton = seccion1.IdCanton;
                    if (seccion1.IdParroquia != null)
                        resp1_Global.IdParroquia = seccion1.IdParroquia;
                    if (seccion1.Direccion.Length > 0)
                        resp1_Global.Direccion = seccion1.Direccion;
                    if (seccion1.Web.Length > 0)
                        resp1_Global.Web = seccion1.Web;
                    if (seccion1.Email.Length > 0)
                        resp1_Global.Email = seccion1.Email;
                    resp1_Global.UpdatedAt = DateTime.Now;

                    try
                    {
                        _unitOfWork.RadRespuesta1_1Repository.Update(resp1_Global);
                        await _unitOfWork.SaveChangesAsync();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }

                }
            }
            
        }

        public async Task<bool> InsertData_Radiografia_seccion2(Seccion2DTO seccion2,string slug)
        {
            
            var org_id = await _unitOfWork.OrganizacionesRepository.GetById(seccion2.IdOrganizacion);
            var rad_id = await _unitOfWork.RadiografiasRepository.GetRadiografia(seccion2.IdRadiografia);
            if (org_id == null || rad_id == null)
            {
                if (org_id == null && rad_id == null)
                    throw new BusinessException("Radiografiía and Organization doesn't exist");
                else if (org_id == null)
                    throw new BusinessException("Organization doesn't exist");
                else
                    throw new BusinessException("Radiografia doesn't exist");
            }

            if (seccion2.IdGrupo != null) //Grupo de trabajo
            {
                CoreGrupos gru_id = await _unitOfWork.GrupostrabajoRepository.GetById((long)seccion2.IdGrupo);
                if (gru_id == null)
                    throw new BusinessException("Grupo de Trabajo doesn't exist");
            }

            switch (slug)
            {
                case "datos-descriptivos": //2A
                    RadRespuestas2A subsec2A = _mapper.Map<RadRespuestas2A>(seccion2);
                    if (seccion2.IdGrupo != null) //
                    {
                        RadRespuestas2A respGlobal_2A = _unitOfWork.RadRespuestas2ARepository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == seccion2.IdGrupo && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdRadiografia==seccion2.IdRadiografia);
                        if(respGlobal_2A != null) //significa que hay fila previa
                        {
                            //throw new BusinessException("Ya existe registro previo");
                            if(subsec2A.IdTipologia != null)
                                respGlobal_2A.IdTipologia = subsec2A.IdTipologia;
                            if (subsec2A.EsMatriz != null)
                                respGlobal_2A.EsMatriz = subsec2A.EsMatriz;
                            if (subsec2A.FechaConstitucion != null)
                                respGlobal_2A.FechaConstitucion = subsec2A.FechaConstitucion;
                            if (subsec2A.NEstablecimientos != null)
                                respGlobal_2A.NEstablecimientos = subsec2A.NEstablecimientos;
                            if (subsec2A.NTrabajadores != null)
                                respGlobal_2A.NTrabajadores = subsec2A.NTrabajadores;
                            respGlobal_2A.UpdatedAt = DateTime.Now;
                            try
                            {
                                _unitOfWork.RadRespuestas2ARepository.Update(respGlobal_2A);
                                await _unitOfWork.SaveChangesAsync();
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }

                        //throw new BusinessException("no existe previo");
                        //en caso de que id grupo sea diferente de nulo
                        subsec2A.CreatedAt = DateTime.Now;
                        try
                        {
                            await _unitOfWork.RadRespuestas2ARepository.Add(subsec2A);
                            await _unitOfWork.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }

                    return false;


                case "actividades":
                    //si son diferentes de null puedo continuar

                    RadRespuestas2B1 respGlobal_2B1 = _unitOfWork.RadRespuestas2B1Repository.GetAll().FirstOrDefault(
                        x => x.IdGrupo == seccion2.IdGrupo && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdRadiografia == seccion2.IdRadiografia);
                    if (respGlobal_2B1 != null) //significa que ya existe una fila con esos ID
                    {
                        //throw new BusinessException("existe fila previa");
                        respGlobal_2B1.UpdatedAt = DateTime.Now;
                        try
                        {
                            if (seccion2.ActividadPrincipal != null && seccion2.ActividadPrincipal != "" && seccion2.ActividadPrincipal.Split('_').Length >= 2)
                                respGlobal_2B1.IdActividad = Convert.ToInt64(seccion2.ActividadPrincipal.Split('_')[0]);
                            if (seccion2.ProductoElaborado != null && seccion2.ProductoElaborado != "" && seccion2.ProductoElaborado.Split('_').Length >= 2)
                                respGlobal_2B1.IdProducto = Convert.ToInt64(seccion2.ProductoElaborado.Split('_')[0]);

                            respGlobal_2B1.IdEstado = seccion2.IdEstado;

                            _unitOfWork.RadRespuestas2B1Repository.Update(respGlobal_2B1);
                            await _unitOfWork.SaveChangesAsync();

                            
                            return true;
                            //save_2B = true;
                        }
                        catch
                        {
                                
                            return false;
                        }
                        
                    }
                    else
                    {
                        //creando objecto de subsec2b1
                        RadRespuestas2B1 subsec2b1 = new RadRespuestas2B1();
                        //asignando atributos al nuevo objeto
                        subsec2b1.IdRadiografia = seccion2.IdRadiografia;
                        subsec2b1.IdGrupo = seccion2.IdGrupo;
                        subsec2b1.IdEstado = seccion2.IdEstado;
                        subsec2b1.IdOrganizacion = seccion2.IdOrganizacion;
                        subsec2b1.CreatedAt = DateTime.Now;

                        
                        try
                        {
                            if (seccion2.ActividadPrincipal != null && seccion2.ActividadPrincipal != "" && seccion2.ActividadPrincipal.Split('_').Length >= 2)
                                subsec2b1.IdActividad = Convert.ToInt64(seccion2.ActividadPrincipal.Split('_')[0]);
                            if (seccion2.ProductoElaborado != null && seccion2.ProductoElaborado != "" && seccion2.ProductoElaborado.Split('_').Length >= 2)
                                subsec2b1.IdProducto = Convert.ToInt64(seccion2.ProductoElaborado.Split('_')[0]);

                            await _unitOfWork.RadRespuestas2B1Repository.Add(subsec2b1);
                            await _unitOfWork.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {
                            //throw new BusinessException("f1");
                            return false;
                        }
                        
                    }

                    //guardando 2b
                    //2B2


                case "productos-servicios": //2C
                    IEnumerable<Seccion2CDTO> prod_Serv = seccion2.ProductosServicios.AsEnumerable();
                    bool save_2C = false;

          
                    foreach (Seccion2CDTO prod_s in prod_Serv)
                    {
                        int flag_2C = 0;

                        RadRespuestas2C subsec2C2 = new RadRespuestas2C();

;
                        //flag_2C += 1;

                        try
                        {
                            _unitOfWork.RadRespuestas2CRepository.Update(subsec2C2);
                            await _unitOfWork.SaveChangesAsync();
                            throw new BusinessException("pa");
                            save_2C = true;
                        }
                        catch(Exception error)
                        {
                            throw new BusinessException(error);
                            
                        }
                        
                        throw new BusinessException("p4");
                        if (flag_2C < 1)
                        {
                            RadRespuestas2C subsec2C = _mapper.Map<RadRespuestas2C>(seccion2);
                            subsec2C.CreatedAt = DateTime.Now;
                            try
                            {
                                subsec2C.Producto = prod_s.Producto;
                                subsec2C.Facturacion = (double)prod_s.Facturacion;
                                subsec2C.EsPDisenoPropio = prod_s.EsPDisenoPropio;
                                subsec2C.EsPBajoPlano = prod_s.EsPBajoPlano;
                                subsec2C.EsPSubcontratado = prod_s.EsPSubcontratado;
                                subsec2C.EsSPropio = prod_s.EsSPropio;
                                subsec2C.EsSSubcontratado = prod_s.EsSSubcontratado;
                                await _unitOfWork.RadRespuestas2CRepository.Add(subsec2C);
                                await _unitOfWork.SaveChangesAsync();
                                save_2C = true;
                                throw new BusinessException("p3");
                            }
                            catch
                            {
                                throw new BusinessException("p4");
                            }
                        }
                        
                    }
                    if(save_2C == true)
                    {
                        throw new BusinessException("p2");
                        return true;
                    }
                    else
                    {
                        throw new BusinessException("p1");
                        return false;
                    }

                case "patentes":
                    bool save_2D = false;
                    int flag_2D = 0;
                    //2D1
                    IEnumerable<Seccion2PatentesDTO> patentes = seccion2.Patentes.AsEnumerable();
                    foreach(Seccion2PatentesDTO pat in patentes)
                    {
                        flag_2D = 0;
                        if (!(pat.Tipo != "" || pat.Tipo.Length > 0))
                        {
                            break;
                        }

                        if (seccion2.IdGrupo == null)
                        {
                            RadRespuestas2D1 respGlobal_2D1 = _unitOfWork.RadRespuestas2D1Repository.GetAll().FirstOrDefault(
                                x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.Tipo.ToLower() == pat.Tipo.ToLower() && x.IdEstado == 2);
                            if (respGlobal_2D1 != null)
                            {
                                flag_2D += 1;
                                if (pat.Descripcion != "")
                                    respGlobal_2D1.Descripcion = pat.Descripcion;
                                respGlobal_2D1.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2D1Repository.Update(respGlobal_2D1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2D = true;
                                }
                                catch
                                {
                                    break;
                                }

                            }
                        }
                        if(flag_2D < 1)
                        {
                            RadRespuestas2D1 subsec2D1 = _mapper.Map<RadRespuestas2D1>(seccion2);
                            subsec2D1.CreatedAt = DateTime.Now;
                            try
                            {
                                subsec2D1.Tipo = pat.Tipo;
                                subsec2D1.Descripcion = pat.Descripcion;
                                await _unitOfWork.RadRespuestas2D1Repository.Add(subsec2D1);
                                await _unitOfWork.SaveChangesAsync();
                                save_2D = true;
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }

                    //2D2
                    flag_2D = 0;
                    if(seccion2.IdGrupo == null)
                    {
                        RadRespuestas2D2 respGlobal_2D2 = _unitOfWork.RadRespuestas2D2Repository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdEstado == 2);
                        if (respGlobal_2D2 != null)
                        {
                            flag_2D += 1;
                            if ((seccion2.EsPatentar == false && respGlobal_2D2.EsPatentar == true) || (seccion2.EsPatentar == true && respGlobal_2D2.EsPatentar == false))
                            {
                                respGlobal_2D2.EsPatentar = seccion2.EsPatentar;
                            }
                            if ((seccion2.EsAsesoramiento == false && respGlobal_2D2.EsAsesoramiento == true) || (seccion2.EsAsesoramiento == true && respGlobal_2D2.EsAsesoramiento == false))
                            {
                                respGlobal_2D2.EsAsesoramiento = seccion2.EsAsesoramiento;
                            }

                            respGlobal_2D2.UpdatedAt = DateTime.Now;
                            try
                            {
                                _unitOfWork.RadRespuestas2D2Repository.Update(respGlobal_2D2);
                                await _unitOfWork.SaveChangesAsync();
                                save_2D = true;
                            }
                            catch
                            {}
                        }
                    }
                    if(flag_2D < 1)
                    {
                        RadRespuestas2D2 subsec2D2 = _mapper.Map<RadRespuestas2D2>(seccion2);

                        subsec2D2.CreatedAt = DateTime.Now;
                        try
                        {
                            await _unitOfWork.RadRespuestas2D2Repository.Add(subsec2D2);
                            await _unitOfWork.SaveChangesAsync();
                            save_2D = true;
                        }
                        catch
                        {}
                    }

                    if (save_2D == true)
                        return true;
                    else
                        return false;

                case "mercado-geografico": //2E
                    int flag_2E = 0;
                    bool save_2E = false;

                    if(seccion2.PorcentajeMercadoLocal != null) //IdMercado = 1
                    {

                        if (seccion2.IdGrupo == null)
                        {
                            RadRespuestas2E respGlobal_2E = _unitOfWork.RadRespuestas2ERepository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdMercado == 1 && x.IdEstado == 2);
                            if (respGlobal_2E != null)
                            {
                                flag_2E += 1;
                                respGlobal_2E.Porcentaje = (double)seccion2.PorcentajeMercadoLocal;
                                respGlobal_2E.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2ERepository.Update(respGlobal_2E);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2E = true;
                                }
                                catch
                                { }
                            }
                        }
                        
                        if(flag_2E < 1)
                        {
                            RadRespuestas2E subsec2E = _mapper.Map<RadRespuestas2E>(seccion2);
                            subsec2E.IdMercado = 1;
                            subsec2E.Porcentaje = (double)seccion2.PorcentajeMercadoLocal;
                            subsec2E.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2ERepository.Add(subsec2E);
                                await _unitOfWork.SaveChangesAsync();
                                save_2E = true;
                            }
                            catch
                            {}
                        }
                    }

                    if (seccion2.PorcentajeMercadoProvincial != null)
                    {
                        if (seccion2.IdGrupo != null)
                        {
                            RadRespuestas2E respGlobal_2E = _unitOfWork.RadRespuestas2ERepository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == seccion2.IdGrupo && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdMercado == 2 && x.IdEstado == seccion2.IdEstado);
                            if (respGlobal_2E != null)
                            {
                                
                                flag_2E += 1;
                                respGlobal_2E.Porcentaje = (double)seccion2.PorcentajeMercadoProvincial;
                                respGlobal_2E.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2ERepository.Update(respGlobal_2E);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2E = true;
                                }
                                catch
                                { }
                            }
                        }

                        if (flag_2E < 1)
                        {
                            RadRespuestas2E subsec2E = new RadRespuestas2E();
                            subsec2E.IdEstado = seccion2.IdEstado;
                            subsec2E.IdGrupo = seccion2.IdGrupo;
                            subsec2E.IdRadiografia = seccion2.IdRadiografia;
                            subsec2E.IdOrganizacion = seccion2.IdOrganizacion;

                            subsec2E.IdMercado = 2;
                            subsec2E.Porcentaje = (double)seccion2.PorcentajeMercadoProvincial;
                            subsec2E.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2ERepository.Add(subsec2E);
                                await _unitOfWork.SaveChangesAsync();
                                save_2E = true;
                            }
                            catch
                            { }
                        }

                    }

                    if (seccion2.PorcentajeMercadoNacional != null)
                    {
                        flag_2E = 0;
                        if (seccion2.IdGrupo != null)
                        {
                            RadRespuestas2E respGlobal_2E = _unitOfWork.RadRespuestas2ERepository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == seccion2.IdGrupo && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdMercado == 3 && x.IdEstado == seccion2.IdEstado);
                            if (respGlobal_2E != null)
                            {

                                flag_2E += 1;
                                respGlobal_2E.Porcentaje = (double)seccion2.PorcentajeMercadoNacional;
                                respGlobal_2E.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2ERepository.Update(respGlobal_2E);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2E = true;
                                }
                                catch
                                { }
                            }
                        }

                        if (flag_2E < 1)
                        {
                            RadRespuestas2E subsec2E = new RadRespuestas2E();
                            subsec2E.IdEstado = seccion2.IdEstado;
                            subsec2E.IdGrupo = seccion2.IdGrupo;
                            subsec2E.IdRadiografia = seccion2.IdRadiografia;
                            subsec2E.IdOrganizacion = seccion2.IdOrganizacion;

                            subsec2E.IdMercado = 3;
                            subsec2E.Porcentaje = (double)seccion2.PorcentajeMercadoNacional;
                            subsec2E.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2ERepository.Add(subsec2E);
                                await _unitOfWork.SaveChangesAsync();
                                save_2E = true;
                            }
                            catch
                            { }
                        }
                    }

                    if (seccion2.PorcentajeMercadoInternacional != null)
                    {
                        
                        flag_2E = 0;
                        if (seccion2.IdGrupo != null)
                        {
                            RadRespuestas2E respGlobal_2E = _unitOfWork.RadRespuestas2ERepository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == seccion2.IdGrupo && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdMercado == 4 && x.IdEstado == seccion2.IdEstado);
                            if (respGlobal_2E != null)
                            {

                                flag_2E += 1;
                                respGlobal_2E.Porcentaje = (double)seccion2.PorcentajeMercadoInternacional;
                                respGlobal_2E.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2ERepository.Update(respGlobal_2E);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2E = true;
                                }
                                catch
                                { }
                            }
                        }

                        if (flag_2E < 1)
                        {
                            RadRespuestas2E subsec2E = new RadRespuestas2E();
                            subsec2E.IdEstado = seccion2.IdEstado;
                            subsec2E.IdGrupo = seccion2.IdGrupo;
                            subsec2E.IdRadiografia = seccion2.IdRadiografia;
                            subsec2E.IdOrganizacion = seccion2.IdOrganizacion;

                            subsec2E.IdMercado = 4;
                            subsec2E.Porcentaje = (double)seccion2.PorcentajeMercadoInternacional;
                            subsec2E.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2ERepository.Add(subsec2E);
                                await _unitOfWork.SaveChangesAsync();
                                save_2E = true;
                            }
                            catch
                            { }
                        }
                    }
                    
                    if (save_2E == true)
                        return true;
                    else
                        return false;

                case "cliente":
                    bool save_2F = false;

                    if (seccion2.IdMercadoGeogragicoEmpresaPrivada != null)
                    {
                        //throw new BusinessException(seccion2.IdMercadoGeogragicoEmpresaPrivada.ToString());

                        RadRespuestas2F1 subsec2F1 = new RadRespuestas2F1();
                        subsec2F1.IdEstado = seccion2.IdEstado;
                        subsec2F1.IdGrupo = seccion2.IdGrupo;
                        subsec2F1.IdOrganizacion = seccion2.IdOrganizacion;
                        subsec2F1.IdRadiografia = seccion2.IdRadiografia;

                        if (seccion2.IdGrupo != null)
                        {
                            subsec2F1.IdCliente = 1;
                            subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaPrivada;
                            subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaPrivada;
                            subsec2F1.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                await _unitOfWork.SaveChangesAsync();
                                save_2F = true;
                            }
                            catch
                            {}
                        }
                        else
                        {
                            RadRespuestas2F1 respGlobal_2F1 = _unitOfWork.RadRespuestas2F1Repository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdCliente == 1 && x.IdEstado == 2);

                            if (respGlobal_2F1 != null)
                            {
                                if(seccion2.IdMercadoGeogragicoEmpresaPrivada != null && seccion2.IdMercadoGeogragicoEmpresaPrivada > 0)
                                    respGlobal_2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaPrivada;
                                if(seccion2.PorcentajeEmpresaPrivada != null)
                                    respGlobal_2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaPrivada;
                                respGlobal_2F1.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2F1Repository.Update(respGlobal_2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                            else
                            {
                                subsec2F1.IdCliente = 1;
                                subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaPrivada;
                                subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaPrivada;
                                subsec2F1.CreatedAt = DateTime.Now;
                                try
                                {
                                    await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                        }
                        
                    }

                    if (seccion2.IdMercadoGeogragicoEmpresaPublica != null)
                    {
                        RadRespuestas2F1 subsec2F1 = new RadRespuestas2F1();
                        subsec2F1.IdEstado = seccion2.IdEstado;
                        subsec2F1.IdGrupo = seccion2.IdGrupo;
                        subsec2F1.IdOrganizacion = seccion2.IdOrganizacion;
                        subsec2F1.IdRadiografia = seccion2.IdRadiografia;


                        if (seccion2.IdGrupo != null)
                        {
                            subsec2F1.IdCliente = 2;
                            subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaPublica;
                            subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaPublica;
                            subsec2F1.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                await _unitOfWork.SaveChangesAsync();
                                save_2F = true;
                            }
                            catch
                            { }
                        }
                        else
                        {
                            RadRespuestas2F1 respGlobal_2F1 = _unitOfWork.RadRespuestas2F1Repository.GetAll().FirstOrDefault(
                                x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdCliente == 2 && x.IdEstado == 2);

                            if (respGlobal_2F1 != null)
                            {
                                if (seccion2.IdMercadoGeogragicoEmpresaPublica != null && seccion2.IdMercadoGeogragicoEmpresaPublica > 0)
                                    respGlobal_2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaPublica;
                                if (seccion2.PorcentajeEmpresaPublica != null)
                                    respGlobal_2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaPublica;
                                respGlobal_2F1.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2F1Repository.Update(respGlobal_2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                            else
                            {
                                subsec2F1.IdCliente = 2;
                                subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaPublica;
                                subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaPublica;
                                subsec2F1.CreatedAt = DateTime.Now;
                                try
                                {
                                    await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                        }
                        
                    }

                    if (seccion2.IdMercadoGeogragicoEmpresaMixta != null)
                    {
                        //throw new BusinessException("break");
                        RadRespuestas2F1 subsec2F1 = new RadRespuestas2F1();
                        subsec2F1.IdEstado = seccion2.IdEstado;
                        subsec2F1.IdGrupo = seccion2.IdGrupo;
                        subsec2F1.IdOrganizacion = seccion2.IdOrganizacion;
                        subsec2F1.IdRadiografia = seccion2.IdRadiografia;


                        if (seccion2.IdGrupo != null)
                        {
                            subsec2F1.IdCliente = 3;
                            subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaMixta;
                            subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaMixta;
                            subsec2F1.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                await _unitOfWork.SaveChangesAsync();
                                save_2F = true;
                            }
                            catch
                            { }
                        }
                        else
                        {
                            RadRespuestas2F1 respGlobal_2F1 = _unitOfWork.RadRespuestas2F1Repository.GetAll().FirstOrDefault(
                                x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdCliente == 3 && x.IdEstado == 2);

                            if (respGlobal_2F1 != null)
                            {
                                if (seccion2.IdMercadoGeogragicoEmpresaMixta != null && seccion2.IdMercadoGeogragicoEmpresaMixta > 0)
                                    subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaMixta;
                                if (seccion2.PorcentajeEmpresaMixta != null)
                                    subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaMixta;
                                respGlobal_2F1.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2F1Repository.Update(respGlobal_2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                            else
                            {
                                subsec2F1.IdCliente = 3;
                                subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoEmpresaMixta;
                                subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaMixta;
                                subsec2F1.CreatedAt = DateTime.Now;
                                try
                                {
                                    await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                        }
                        
                    }

                    if (seccion2.IdMercadoGeogragicoGeneral != null)
                    {
                        //throw new BusinessException("break");
                        RadRespuestas2F1 subsec2F1 = new RadRespuestas2F1();
                        subsec2F1.IdEstado = seccion2.IdEstado;
                        subsec2F1.IdGrupo = seccion2.IdGrupo;
                        subsec2F1.IdOrganizacion = seccion2.IdOrganizacion;
                        subsec2F1.IdRadiografia = seccion2.IdRadiografia;

                        if (seccion2.IdGrupo != null)
                        {
                            subsec2F1.IdCliente = 4;
                            subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoGeneral;
                            subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaGeneral;
                            subsec2F1.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                await _unitOfWork.SaveChangesAsync();
                                save_2F = true;
                            }
                            catch
                            { }
                        }
                        else
                        {
                            RadRespuestas2F1 respGlobal_2F1 = _unitOfWork.RadRespuestas2F1Repository.GetAll().FirstOrDefault(
                                x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdCliente == 4 && x.IdEstado == 2);

                            if (respGlobal_2F1 != null)
                            {
                                if (seccion2.IdMercadoGeogragicoGeneral != null && seccion2.IdMercadoGeogragicoGeneral > 0)
                                    respGlobal_2F1.IdMercado = seccion2.IdMercadoGeogragicoGeneral;
                                if (seccion2.PorcentajeEmpresaGeneral != null)
                                    respGlobal_2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaGeneral;
                                respGlobal_2F1.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2F1Repository.Update(respGlobal_2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                            else
                            {
                                subsec2F1.IdCliente = 4;
                                subsec2F1.IdMercado = seccion2.IdMercadoGeogragicoGeneral;
                                subsec2F1.Porcentaje = (double)seccion2.PorcentajeEmpresaGeneral;
                                subsec2F1.CreatedAt = DateTime.Now;
                                try
                                {
                                    await _unitOfWork.RadRespuestas2F1Repository.Add(subsec2F1);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                        }
                        
                    }

                    if(seccion2.EsAmpliar != null || (seccion2.Cuales != null && seccion2.Cuales.Length > 0))
                    {
                        if(seccion2.IdGrupo != null)
                        {
                            RadRespuestas2F2 subsec2F2 = new RadRespuestas2F2();
                            subsec2F2.IdEstado = seccion2.IdEstado;
                            subsec2F2.IdGrupo = seccion2.IdGrupo;
                            subsec2F2.IdOrganizacion = seccion2.IdOrganizacion;
                            subsec2F2.IdRadiografia = seccion2.IdRadiografia;

                            subsec2F2.CreatedAt = DateTime.Now;
                            try
                            {
                                await _unitOfWork.RadRespuestas2F2Repository.Add(subsec2F2);
                                await _unitOfWork.SaveChangesAsync();
                                save_2F = true;
                            }
                            catch
                            {}
                        }
                        else
                        {
                            RadRespuestas2F2 respGlobal_2F2 = _unitOfWork.RadRespuestas2F2Repository.GetAll().FirstOrDefault(
                                x => x.IdGrupo == null && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdEstado == 2);
                            if (respGlobal_2F2 != null)
                            {
                                if (seccion2.EsAmpliar != null)
                                    respGlobal_2F2.EsAmpliar = seccion2.EsAmpliar;
                                if (seccion2.Cuales != null && seccion2.Cuales.Length > 0)
                                    respGlobal_2F2.Cuales = seccion2.Cuales;

                                respGlobal_2F2.UpdatedAt = DateTime.Now;
                                try
                                {
                                    _unitOfWork.RadRespuestas2F2Repository.Update(respGlobal_2F2);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                { }
                            }
                            else
                            {
                                RadRespuestas2F2 subsec2F2 = new RadRespuestas2F2();
                                subsec2F2.IdEstado = seccion2.IdEstado;
                                subsec2F2.IdGrupo = seccion2.IdGrupo;
                                subsec2F2.IdOrganizacion = seccion2.IdOrganizacion;
                                subsec2F2.IdRadiografia = seccion2.IdRadiografia;
                                
                                //    _mapper.Map<RadRespuestas2F2>(seccion2);

                                subsec2F2.CreatedAt = DateTime.Now;
                                try
                                {
                                    await _unitOfWork.RadRespuestas2F2Repository.Add(subsec2F2);
                                    await _unitOfWork.SaveChangesAsync();
                                    save_2F = true;
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    
                    if(save_2F == false)
                        return false;
                    return true;

                case "proveedores":
                 
                    
                    RadRespuestas2G subsec2G = new RadRespuestas2G();
                    //llenando de data el objeto
                    subsec2G.IdOrganizacion = seccion2.IdOrganizacion;
                    subsec2G.IdRadiografia = seccion2.IdRadiografia;
                    subsec2G.IdGrupo = seccion2.IdGrupo;
                    subsec2G.IdEstado = seccion2.IdEstado;

                    subsec2G.CompraMateriaPrima = seccion2.CompraMateriaPrima;
                    subsec2G.CualesMateriaPrima = seccion2.CualesMateriaPrima;
                    subsec2G.PorqueMateriaPrima = seccion2.PorqueMateriaPrima;
                    subsec2G.DesarrollarProveedoresM = seccion2.DesarrollarProveedoresM;
                    subsec2G.CualesProveedoresM = seccion2.CualesProveedoresM;
                    subsec2G.PorqueProveedoresM = seccion2.PorqueProveedoresM;
                    subsec2G.CompraInsumos = seccion2.CompraInsumos;
                    subsec2G.CualesInsumos = seccion2.CualesInsumos;
                    subsec2G.PorqueInsumos = seccion2.PorqueInsumos;
                    subsec2G.DesarrollarProveedoresI = seccion2.DesarrollarProveedoresI;
                    subsec2G.CualesProveedoresI = seccion2.CualesProveedoresI;
                    subsec2G.PorqueProveedoresI = seccion2.PorqueProveedoresI;
                    subsec2G.ExisteInteres = seccion2.ExisteInteres;
                    subsec2G.CualesInteres = seccion2.CualesInteres;

                    RadRespuestas2G respGlobal_2GP = _unitOfWork.RadRespuestas2GRepository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == seccion2.IdGrupo && x.IdOrganizacion == seccion2.IdOrganizacion);


                    if (respGlobal_2GP == null) //Grupo de trabajo
                    {
                        //throw new BusinessException("vamos a agregar");
                        subsec2G.IdProvinciaMateriaPrima = Convert.ToInt64(seccion2.ProvinciaMateriaPrima.Split('_')[0]);
                        subsec2G.IdCantonMateriaPrima = Convert.ToInt64(seccion2.CantonMateriaPrima.Split('_')[0]);
                        subsec2G.IdProvinciaProveedoresM = Convert.ToInt64(seccion2.ProvinciaProveedoresM.Split('_')[0]);
                        subsec2G.IdCantonProveedoresM = Convert.ToInt64(seccion2.CantonProveedoresM.Split('_')[0]);
                        subsec2G.IdProvinciaInsumos = Convert.ToInt64(seccion2.ProvinciaInsumos.Split('_')[0]);
                        subsec2G.IdCantonInsumos = Convert.ToInt64(seccion2.CantonInsumos.Split('_')[0]);
                        subsec2G.IdProvinciaProveedoresI = Convert.ToInt64(seccion2.ProvinciaProveedoresI.Split('_')[0]);
                        subsec2G.IdCantonProveedoresI = Convert.ToInt64(seccion2.CantonProveedoresI.Split('_')[0]);
                        subsec2G.CreatedAt = DateTime.Now;
                        try
                        {
                            await _unitOfWork.RadRespuestas2GRepository.Add(subsec2G);
                            await _unitOfWork.SaveChangesAsync();
                            //throw new BusinessException("bien");

                            return true;
                        }
                        catch
                        {
                           //throw new BusinessException(subsec2G.ToString());
                            return false;
                        }
                    }
                    else
                    {
                        //throw new BusinessException("vamos a actualizar");
                        RadRespuestas2G respGlobal_2G = new RadRespuestas2G();
                        //llenando de data el objeto
                        respGlobal_2G.IdOrganizacion = seccion2.IdOrganizacion;
                        respGlobal_2G.IdRadiografia = seccion2.IdRadiografia;
                        respGlobal_2G.IdGrupo = seccion2.IdGrupo;
                        respGlobal_2G.IdEstado = seccion2.IdEstado;

                        if (seccion2.CompraMateriaPrima != null)
                                respGlobal_2G.CompraMateriaPrima = seccion2.CompraMateriaPrima;
                            if (seccion2.ProvinciaMateriaPrima != "")
                                respGlobal_2G.IdProvinciaMateriaPrima = Convert.ToInt64(seccion2.ProvinciaMateriaPrima.Split('_')[0]);
                            if (seccion2.CantonMateriaPrima != "")
                                respGlobal_2G.IdCantonMateriaPrima = Convert.ToInt64(seccion2.CantonMateriaPrima.Split('_')[0]);
                            if (seccion2.CualesMateriaPrima != "")
                                respGlobal_2G.CualesMateriaPrima = seccion2.CualesMateriaPrima;
                            if (seccion2.PorqueMateriaPrima != "")
                                respGlobal_2G.PorqueMateriaPrima = seccion2.PorqueMateriaPrima;
                            if (seccion2.DesarrollarProveedoresM != null)
                                respGlobal_2G.DesarrollarProveedoresM = seccion2.DesarrollarProveedoresM;
                            if (seccion2.ProvinciaProveedoresM != "")
                                respGlobal_2G.IdProvinciaProveedoresM = Convert.ToInt64(seccion2.ProvinciaProveedoresM.Split('_')[0]);
                            if (seccion2.CantonProveedoresM != "")
                                respGlobal_2G.IdCantonProveedoresM = Convert.ToInt64(seccion2.CantonProveedoresM.Split('_')[0]);
                            if (seccion2.CualesProveedoresM != "")
                                respGlobal_2G.CualesProveedoresM = seccion2.CualesProveedoresM;
                            if (seccion2.PorqueProveedoresM != "")
                                respGlobal_2G.PorqueProveedoresM = seccion2.PorqueProveedoresM;
                            if (seccion2.CompraInsumos != null)
                                respGlobal_2G.CompraInsumos = seccion2.CompraInsumos;
                            if (seccion2.ProvinciaInsumos != "")
                                respGlobal_2G.IdProvinciaInsumos = Convert.ToInt64(seccion2.ProvinciaInsumos.Split('_')[0]);
                            if (seccion2.CantonInsumos != "")
                                respGlobal_2G.IdCantonInsumos = Convert.ToInt64(seccion2.CantonInsumos.Split('_')[0]);
                            if (seccion2.CualesInsumos != "")
                                respGlobal_2G.CualesInsumos = seccion2.CualesInsumos;
                            if (seccion2.PorqueInsumos != "")
                                respGlobal_2G.PorqueInsumos = seccion2.PorqueInsumos;
                            if (seccion2.DesarrollarProveedoresI != null)
                                respGlobal_2G.DesarrollarProveedoresI = seccion2.DesarrollarProveedoresI;
                            if (seccion2.ProvinciaProveedoresI != "")
                                respGlobal_2G.IdProvinciaProveedoresI = Convert.ToInt64(seccion2.ProvinciaProveedoresI.Split('_')[0]);
                            if (seccion2.CantonProveedoresI != "")
                                respGlobal_2G.IdCantonProveedoresI = Convert.ToInt64(seccion2.CantonProveedoresI.Split('_')[0]);
                            if (seccion2.CualesProveedoresI != "")
                                respGlobal_2G.CualesProveedoresI = seccion2.CualesProveedoresI;
                            if (seccion2.PorqueProveedoresI != "")
                                respGlobal_2G.PorqueProveedoresI = seccion2.PorqueProveedoresI;
                            if (seccion2.ExisteInteres != null)
                                respGlobal_2G.ExisteInteres = seccion2.ExisteInteres;
                            if (seccion2.CualesInteres != "")
                                respGlobal_2G.CualesInteres = seccion2.CualesInteres;

                            respGlobal_2G.UpdatedAt = DateTime.Now;
                            try
                            {
                                _unitOfWork.RadRespuestas2GRepository.Update(respGlobal_2G);
                                await _unitOfWork.SaveChangesAsync();
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                    }

                case "competencia-posicionamiento":
                    
                    //RadRespuestas2H subsec2H = _mapper.Map<RadRespuestas2H>(seccion2);
                    RadRespuestas2H subsec2H = new RadRespuestas2H();

                    subsec2H.IdCompetencia = seccion2.IdCompetencia;
                    subsec2H.IdEstado = seccion2.IdEstado;
                    subsec2H.IdGrupo = seccion2.IdGrupo;
                    subsec2H.IdOrganizacion = seccion2.IdOrganizacion;
                    subsec2H.IdPosicionamiento = seccion2.IdPosicionamiento;
                    subsec2H.IdRadiografia = seccion2.IdRadiografia;

                    RadRespuestas2H respGlobal_2HP = _unitOfWork.RadRespuestas2HRepository.GetAll().FirstOrDefault(
                            x => x.IdGrupo == seccion2.IdGrupo && x.IdOrganizacion == seccion2.IdOrganizacion && x.IdEstado == seccion2.IdEstado);

                    if (respGlobal_2HP == null) //Grupo de trabajo
                    {
                        subsec2H.CreatedAt = DateTime.Now;
                        try
                        {
                            await _unitOfWork.RadRespuestas2HRepository.Add(subsec2H);
                            await _unitOfWork.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        subsec2H.UpdatedAt = DateTime.Now;
                        try
                        {
                            _unitOfWork.RadRespuestas2HRepository.Update(subsec2H);
                            await _unitOfWork.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }

                case "foda":

                    //RadRespuestas2H subsec2H = _mapper.Map<RadRespuestas2H>(seccion2);
                    RadRespuestas3B subSecFoda = new RadRespuestas3B();
                    return true;
                    
                default:
                    return false;
            }

        }


        IEnumerable<object> IRadiografiaService.GetRadiografias2(string query)
        {
            return _seccionRadiografia.radiografia_estado_organizacion(query);
        }

        public Task<bool> InsertData_Radiografia_seccion1_datosContacto(RadRespuestas11 seccion1)
        {
            throw new NotImplementedException();
        }
    }
}
