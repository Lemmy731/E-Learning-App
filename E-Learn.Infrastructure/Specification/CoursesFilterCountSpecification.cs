using E_Learn.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Specification
{
    public class CoursesFilterCountSpecification : SpecificationImplement<Course>
    {
        public CoursesFilterCountSpecification(CourseParams courseParams) : base(x =>
        (string.IsNullOrEmpty(courseParams.Search) || x.Title.ToLower().Contains(courseParams.Search)) &&
        (!courseParams.CategoryId.HasValue || x.CategoryId == courseParams.CategoryId))
        {
        }
    }
}
