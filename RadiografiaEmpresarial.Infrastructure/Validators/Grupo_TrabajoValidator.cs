using FluentValidation;
using RadiografiaEmpresarial.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Infrastructure.Validators
{
    public class Grupo_TrabajoValidator : AbstractValidator<CoreGruposDTO>
    {
        public Grupo_TrabajoValidator()
        {
            RuleFor(grupo => grupo.IdEstado).NotNull();
            RuleFor(grupo => grupo.IdOrganizacion).NotNull();
            RuleFor(grupo => grupo.IdSupervisador).NotNull();
            RuleFor(grupo => grupo.IdVinculo).NotNull();

        }
    }
}
