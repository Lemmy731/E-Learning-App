using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Specification
{
    public class SpecificationImplement<T> : ISpecification<T>
    {
        public SpecificationImplement()
        {
        }

        public SpecificationImplement(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Include { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Sort { get; private set; }

        public Expression<Func<T, object>> SortByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaging { get; private set; }

        protected void IncludeMethod(Expression<Func<T, object>> expression)
        {
            Include.Add(expression);
        }
        protected void SortMethod(Expression<Func<T, object>> sortExpression)
        {
            Sort = sortExpression;
        }
        protected void SortByDescendingMethod(Expression<Func<T, object>> sortDescendingExpression)
        {
            SortByDescending = sortDescendingExpression;
        }
        protected void ApplyPagination(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPaging= true;
        }
    }
}
