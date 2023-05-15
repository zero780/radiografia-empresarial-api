using AutoMapper;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CoreGrupos, CoreGruposDTO>();
            CreateMap<CoreGruposDTO, CoreGrupos>();
            CreateMap<AuthUsuarios, AuthUsuarioDTO>();
            CreateMap<AuthUsuarioDTO, AuthUsuarios>();
            CreateMap<AuthRoles, AuthRolesDTO>();
            CreateMap<AuthRolesDTO, AuthRoles>();
            CreateMap<TipoReportes, TipoReporteDTO>();
            CreateMap<TipoReporteDTO, TipoReportes>();
            CreateMap<RadRespuestas2A, Seccion2DTO>();
            CreateMap<Seccion2DTO, RadRespuestas2A>();
        }
    }
}
