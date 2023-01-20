using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>Criteria { get; }
        List<Expression<Func<T, object>>> Include { get; }  
        Expression<Func<T, object>> Sort { get; }
        Expression<Func<T, object>> SortByDescending{ get; }

        int Take { get; }   
        int Skip { get; }   
        bool IsPaging { get; }  
    }
}
