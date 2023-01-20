using E_Learn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Specification
{
    public class CategoryWithCourseSpecification : SpecificationImplement<Category>
    {
        public CategoryWithCourseSpecification(int id) : base(x => x.Id == id)
        {
            IncludeMethod(c => c.Courses);
            SortMethod(x => x.Id);
        }
    }
}
