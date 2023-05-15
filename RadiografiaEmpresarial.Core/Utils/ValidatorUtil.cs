using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiografiaEmpresarial.Core.Utils
{
    public class ValidatorUtil
    {
        //private string _email;
        private readonly IUnitOfWork _unitOfWork;
        

        public ValidatorUtil( IUnitOfWork unitOfWork)
        {
            //_email = email;
            _unitOfWork = unitOfWork;
        }

        public long IsSupervisor(string email)
        {
            var usuarios = _unitOfWork.AuthUsuarioRepository.GetAll();
            var superv = usuarios.Where(x => x.AuthRoUsuariosIdUsuarioNavigation.Select(y => y.IdRol).Contains(3)).FirstOrDefault(z => z.Email == email);
            if(superv == null)
            {
                return 0;
            }
            return superv.Id;

        }
    }
}
