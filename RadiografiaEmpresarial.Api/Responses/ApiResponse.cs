using RadiografiaEmpresarial.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse( T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public MetaData Meta { get; set; }
    }
}
