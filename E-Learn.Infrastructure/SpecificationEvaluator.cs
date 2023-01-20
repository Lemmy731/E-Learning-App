using E_Learn.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure
{
    public class SpecificationEvaluator<T> where T: class
    {
        public static IQueryable<T> GetQueryable(IQueryable<T> inputQuery, ISpecification<T> spec )
        {
            var query = inputQuery;
            if(spec.Criteria != null) 
            {
                query = query.Where(spec.Criteria);
               
            }
            if (spec.Sort != null)
            {
                query = query.OrderBy(spec.Sort); //sort ascending order

            }
            if (spec.SortByDescending != null)
            {
                query = query.OrderByDescending(spec.SortByDescending);//sort descending order

            }
            if(spec.IsPaging ==true) 
            {
                query = query.Skip(spec.Skip).Take(spec.Take);//pagination
            }
            query = spec.Include.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

    }
}
