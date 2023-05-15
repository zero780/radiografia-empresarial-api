using RadiografiaEmpresarial.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        List<T> GetAllAsNoTracking();
        Task<T> GetById(long id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(long id);
    }
}
