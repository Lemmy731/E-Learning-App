using E_Learn.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Specification
{
    public class CoursesWithCategorySpecification : SpecificationImplement<Course>
    {
        public CoursesWithCategorySpecification(CourseParams courseParams): base(x => 
        (string.IsNullOrEmpty(courseParams.Search)|| x.Title.ToLower().Contains(courseParams.Search))&&
        (!courseParams.CategoryId.HasValue || x.CategoryId == courseParams.CategoryId)
        )
        {
            IncludeMethod(x=> x.Category);
            IncludeMethod(x => x.Requirements);
            IncludeMethod(x => x.Learnings);
            ApplyPagination(courseParams.PageSize, courseParams.PageSize * (courseParams.PageIndex - 1));
            if(!string.IsNullOrEmpty(courseParams.Sort))
            {
                switch(courseParams.Sort) 
                {
                    case "priceAscending"://sort price ascending order
                        SortMethod(c => c.Price);
                        break;
                    case "priceDescending"://sort price descending order
                        SortByDescendingMethod(c => c.Price);
                        break;
                        default:
                        SortMethod(c => c.Category); 
                        break;
                }
            }
        }
        
        public CoursesWithCategorySpecification(Guid Id) : base(x => x.Id == Id)
        {
            IncludeMethod(x=> x.Requirements);
            IncludeMethod(x => x.Learnings);
             IncludeMethod(x => x.Category);
            SortMethod(x=> x.Id); 
        }
    }
}
