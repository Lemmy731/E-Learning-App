using E_Learn.Infrastructure.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.IRepo
{
    public interface IGenericRepo<T>
    {
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> GetByIdAsync(dynamic id);
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IEnumerable<T>> ListWithSpec(ISpecification<T> spec);
        Task<int> CountResultAsync(ISpecification<T> spec);  
    }
}
