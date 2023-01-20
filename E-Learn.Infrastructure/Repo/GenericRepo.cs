using E_Learn.Infrastructure.IRepo;
using E_Learn.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly StoreContext _storeContext;

        public GenericRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<int> CountResultAsync(ISpecification<T> spec)
        {
            return await ApplySpec(spec).CountAsync();    
        }

        public async Task<IEnumerable<T>> GetByIdAsync(dynamic id)
        {
            return await _storeContext.Set<T>().FindAsync(id);  
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
           return  ApplySpec(spec).FirstOrDefault();   
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
          return  await _storeContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListWithSpec(ISpecification<T> spec)
        {
            return await ApplySpec(spec).ToListAsync(); 
        }
        private IQueryable<T> ApplySpec(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQueryable(_storeContext.Set<T>().AsQueryable(), spec);
        }
    }
}
