﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadiografiaEmpresarial.Core.Entities
{
    public partial class EstadoRespuestas : BaseEntity
    {
        public EstadoRespuestas()
        {
            RadRespuestas11 = new HashSet<RadRespuestas11>();
            RadRespuestas2A = new HashSet<RadRespuestas2A>();
            RadRespuestas2B1 = new HashSet<RadRespuestas2B1>();
            RadRespuestas2B2 = new HashSet<RadRespuestas2B2>();
            RadRespuestas2C = new HashSet<RadRespuestas2C>();
            RadRespuestas2D1 = new HashSet<RadRespuestas2D1>();
            RadRespuestas2D2 = new HashSet<RadRespuestas2D2>();
            RadRespuestas2E = new HashSet<RadRespuestas2E>();
            RadRespuestas2F1 = new HashSet<RadRespuestas2F1>();
            RadRespuestas2F2 = new HashSet<RadRespuestas2F2>();
            RadRespuestas2G = new HashSet<RadRespuestas2G>();
            RadRespuestas2H = new HashSet<RadRespuestas2H>();
            RadRespuestas3A = new HashSet<RadRespuestas3A>();
            RadRespuestas3B = new HashSet<RadRespuestas3B>();
            RadRespuestas4A1 = new HashSet<RadRespuestas4A1>();
            RadRespuestas4A2 = new HashSet<RadRespuestas4A2>();
            RadRespuestas4B1 = new HashSet<RadRespuestas4B1>();
            RadRespuestas4B2 = new HashSet<RadRespuestas4B2>();
            RadRespuestas4C = new HashSet<RadRespuestas4C>();
            RadRespuestas4D = new HashSet<RadRespuestas4D>();
            RadRespuestas4E = new HashSet<RadRespuestas4E>();
            RadRespuestas5A = new HashSet<RadRespuestas5A>();
            RadRespuestas6A = new HashSet<RadRespuestas6A>();
            RadRespuestas6B1 = new HashSet<RadRespuestas6B1>();
            RadRespuestas6B2 = new HashSet<RadRespuestas6B2>();
            RadRespuestas6C1IdContinenteNavigation = new HashSet<RadRespuestas6C1>();
            RadRespuestas6C1IdEstadoNavigation = new HashSet<RadRespuestas6C1>();
            RadRespuestas6C1IdPaisNavigation = new HashSet<RadRespuestas6C1>();
            RadRespuestas6C2 = new HashSet<RadRespuestas6C2>();
            RadRespuestas6D = new HashSet<RadRespuestas6D>();
            RadRespuestas6E = new HashSet<RadRespuestas6E>();
        }

        //public long Id { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<RadRespuestas11> RadRespuestas11 { get; set; }
        public virtual ICollection<RadRespuestas2A> RadRespuestas2A { get; set; }
        public virtual ICollection<RadRespuestas2B1> RadRespuestas2B1 { get; set; }
        public virtual ICollection<RadRespuestas2B2> RadRespuestas2B2 { get; set; }
        public virtual ICollection<RadRespuestas2C> RadRespuestas2C { get; set; }
        public virtual ICollection<RadRespuestas2D1> RadRespuestas2D1 { get; set; }
        public virtual ICollection<RadRespuestas2D2> RadRespuestas2D2 { get; set; }
        public virtual ICollection<RadRespuestas2E> RadRespuestas2E { get; set; }
        public virtual ICollection<RadRespuestas2F1> RadRespuestas2F1 { get; set; }
        public virtual ICollection<RadRespuestas2F2> RadRespuestas2F2 { get; set; }
        public virtual ICollection<RadRespuestas2G> RadRespuestas2G { get; set; }
        public virtual ICollection<RadRespuestas2H> RadRespuestas2H { get; set; }
        public virtual ICollection<RadRespuestas3A> RadRespuestas3A { get; set; }
        public virtual ICollection<RadRespuestas3B> RadRespuestas3B { get; set; }
        public virtual ICollection<RadRespuestas4A1> RadRespuestas4A1 { get; set; }
        public virtual ICollection<RadRespuestas4A2> RadRespuestas4A2 { get; set; }
        public virtual ICollection<RadRespuestas4B1> RadRespuestas4B1 { get; set; }
        public virtual ICollection<RadRespuestas4B2> RadRespuestas4B2 { get; set; }
        public virtual ICollection<RadRespuestas4C> RadRespuestas4C { get; set; }
        public virtual ICollection<RadRespuestas4D> RadRespuestas4D { get; set; }
        public virtual ICollection<RadRespuestas4E> RadRespuestas4E { get; set; }
        public virtual ICollection<RadRespuestas5A> RadRespuestas5A { get; set; }
        public virtual ICollection<RadRespuestas6A> RadRespuestas6A { get; set; }
        public virtual ICollection<RadRespuestas6B1> RadRespuestas6B1 { get; set; }
        public virtual ICollection<RadRespuestas6B2> RadRespuestas6B2 { get; set; }
        public virtual ICollection<RadRespuestas6C1> RadRespuestas6C1IdContinenteNavigation { get; set; }
        public virtual ICollection<RadRespuestas6C1> RadRespuestas6C1IdEstadoNavigation { get; set; }
        public virtual ICollection<RadRespuestas6C1> RadRespuestas6C1IdPaisNavigation { get; set; }
        public virtual ICollection<RadRespuestas6C2> RadRespuestas6C2 { get; set; }
        public virtual ICollection<RadRespuestas6D> RadRespuestas6D { get; set; }
        public virtual ICollection<RadRespuestas6E> RadRespuestas6E { get; set; }
    }
}
