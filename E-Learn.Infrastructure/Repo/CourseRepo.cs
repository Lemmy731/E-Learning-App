using E_Learn.Entity;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;
using E_Learn.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Repo
{
     public class CourseRepo: ICourseRepo
    {
        private readonly StoreContext _storeContext;
        public CourseRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;   
        }
        public async Task<IEnumerable<Course>> GetCourseById(Guid id)
        {
            var result =  _storeContext.Courses.Include(c => c.Category)
                .Include(c => c.Learnings)
                .Include(c => c.Requirements)
                .Where(c => c.Id == id);   
            return result;
              
        }

        public async Task<IReadOnlyList<Course>> GetAllCourse()
        {
            var result = await _storeContext.Courses.Include(x => x.Category)
             .ToListAsync(); 
           return result;  
        }
        public IEnumerable<Course> GetCourseByCategory(int Id)
        {
            var response = _storeContext.Courses.Where(x => x.CategoryId == Id);
            return response;
        }

        public async Task<string> AddCourse(Course course)
        {
           
            
            
                var res1 = await _storeContext.Courses.AddAsync(course);
                var res = await _storeContext.SaveChangesAsync();
                if (res < 1)
                    return "unsuccessful";

                return "successful";

           
               
            
            
           
              
            
            
            

        }
    }
}
