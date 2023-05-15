using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormularioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
