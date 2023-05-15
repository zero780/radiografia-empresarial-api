using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(Exception error)
        {

        }

        public BusinessException(string message) : base(message)
        {

        }
    }
}
