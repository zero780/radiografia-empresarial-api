using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.DTOs
{
    public  class Seccion2DTO
    {
        //Global
        public long IdOrganizacion { get; set; }
        public long IdRadiografia { get; set; }
        public long? IdGrupo { get; set; }
        public long IdEstado { get; set; }
        //2A (1-1)
        public long? IdTipologia { get; set; }
        public bool? EsMatriz { get; set; }
        public DateTime? FechaConstitucion { get; set; }
        public int? NEstablecimientos { get; set; }
        public int? NTrabajadores { get; set; }
        //2B1 (1-1)
        public string ActividadPrincipal { get; set; } //id_String
        public string ProductoElaborado { get; set; } //id_String
        //2B2 (1-*)
        public virtual ICollection<string> ActividadesSecundarias { get; set; } //id_string
        //2C (1-*)
        public virtual ICollection<Seccion2CDTO> ProductosServicios { get; set; }
        public virtual bool? esPBajoPlano { get; set; }
        public virtual bool? esPDisenoPropio { get; set; }

        public virtual bool? esSPropio { get; set; }
        public virtual bool? esSSubcontrato { get; set; }
        public virtual double facturacion { get; set; }

        public virtual string producto { get; set; }


        //2D1 (1-*)

        public virtual ICollection<Seccion2PatentesDTO> Patentes { get; set; }
        //2D2 (1-1)
        public bool? EsPatentar { get; set; }
        public bool? EsAsesoramiento { get; set; }
        //2E (1-1) pero varios registros
        //public long? IdMercado { get; set; } //2E, 2F1
        public double? PorcentajeMercadoLocal { get; set; } //IdMercado = 1
        public double? PorcentajeMercadoProvincial { get; set; } //IdMercado = 2
        public double? PorcentajeMercadoNacional { get; set; } //IdMercado = 3
        public double? PorcentajeMercadoInternacional { get; set; } //IdMercado = 4
        //2F1 (1-1) pero varios registros
        //public long? IdCliente { get; set; }
        public long? IdMercadoGeogragicoEmpresaPrivada { get; set; } //IdCliente = 1 -> Guarda el ID del Mercado
        public long? IdMercadoGeogragicoEmpresaPublica { get; set; } //IdCliente = 2
        public long? IdMercadoGeogragicoEmpresaMixta { get; set; } //IdCliente = 3
        public long? IdMercadoGeogragicoGeneral { get; set; } //IdCliente = 4
        public double? PorcentajeEmpresaPrivada { get; set; } //IdCliente = 1 -> Guarda el porcentaje
        public double? PorcentajeEmpresaPublica { get; set; } //IdCliente = 2
        public double? PorcentajeEmpresaMixta { get; set; } //IdCliente = 3
        public double? PorcentajeEmpresaGeneral { get; set; } //IdCliente = 4
        //2F2 (1-1)
        public bool? EsAmpliar { get; set; }
        public string Cuales { get; set; }
        //2G
        public bool? CompraMateriaPrima { get; set; }
        public string ProvinciaMateriaPrima { get; set; } //id_string
        public string CantonMateriaPrima { get; set; } //id_string
        public string CualesMateriaPrima { get; set; }
        public string PorqueMateriaPrima { get; set; }
        public bool? DesarrollarProveedoresM { get; set; }
        public string ProvinciaProveedoresM { get; set; } //id_string
        public string CantonProveedoresM { get; set; } //id_string
        public string CualesProveedoresM { get; set; }
        public string PorqueProveedoresM { get; set; }
        public bool? CompraInsumos { get; set; }
        public string ProvinciaInsumos { get; set; } //id_string
        public string CantonInsumos { get; set; } //id_string
        public string CualesInsumos { get; set; }
        public string PorqueInsumos { get; set; }
        public bool? DesarrollarProveedoresI { get; set; }
        public string ProvinciaProveedoresI { get; set; } //id_string
        public string CantonProveedoresI { get; set; } //id_string
        public string CualesProveedoresI { get; set; }
        public string PorqueProveedoresI { get; set; }
        public bool? ExisteInteres { get; set; }
        public string CualesInteres { get; set; }
        //2H
        public long? IdCompetencia { get; set; }
        public long? IdPosicionamiento { get; set; }
    }
}
