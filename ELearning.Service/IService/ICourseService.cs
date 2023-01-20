using E_Learn.Entity;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;
using E_Learn.Infrastructure.Specification;
using ELearning.Service.MyPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Service.IService
{
    public interface ICourseService
    {
        Task<CourseDTO> GetCourseById(Guid id);
        Task<Pagination<CourseDTO>> GetAllCourse(CourseParams courseParams);
        IEnumerable<Course> GetCourseByCategory(int Id);
        Task<string> AddCourse(CourseDTO courseDTO);

    }
}
