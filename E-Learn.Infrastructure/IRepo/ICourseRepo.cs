using E_Learn.Entity;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Interface
{
    public interface ICourseRepo
    {
        Task<IEnumerable<Course>> GetCourseById(Guid Id);
        Task<IReadOnlyList<Course>> GetAllCourse();
        IEnumerable<Course> GetCourseByCategory(int Id);
        Task<string> AddCourse(Course course);
    }
}
