using AutoMapper;
using E_Learn.Entity;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;
using E_Learn.Infrastructure.Interface;
using E_Learn.Infrastructure.IRepo;
using E_Learn.Infrastructure.Specification;
using ELearning.Service.IService;
using ELearning.Service.MyPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Service.Service
{
     public class CourseService: ICourseService
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepo<Course> _genericRepo;

        public CourseService(ICourseRepo courseRepo, IMapper mapper, IGenericRepo<Course> genericRepo)
        {
          _courseRepo = courseRepo;
          _mapper = mapper;
          _genericRepo = genericRepo;   
        }
        public async Task<CourseDTO> GetCourseById(Guid id)
        {
            //var result = await _courseRepo.GetCourseById(id);
            var spec = new CoursesWithCategorySpecification(id);
            var result = await _genericRepo.GetEntityWithSpec(spec);  
            var res = _mapper.Map<Course, CourseDTO>(result);

          
            return res;  
        }
        public async Task<Pagination<CourseDTO>> GetAllCourse(CourseParams courseParams)
        {
            //var result = await _courseRepo.GetAllCourse();
            var spec = new CoursesWithCategorySpecification(courseParams);
            var countSpec = new CoursesFilterCountSpecification(courseParams);
            var total = await _genericRepo.CountResultAsync(countSpec); 
            var result = await _genericRepo.ListWithSpec(spec);
            var data = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDTO>>(result);
            var res = new Pagination<CourseDTO>(courseParams.PageIndex, courseParams.PageSize, total, data);

            if (res == null)
                return res;
            return res;
        }
        public IEnumerable<Course> GetCourseByCategory(int Id)
        {


            var response = _courseRepo.GetCourseByCategory(Id);
                if (response == null)
                    return response;
                return response;
            
            
            
        }
        public async Task<string> AddCourse(CourseDTO courseDTO)
        {

            try
            {
                var course = _mapper.Map<CourseDTO, Course>(courseDTO);
                var res = await _courseRepo.AddCourse(course);
                if (res == "unsuccessful")
                    return res;
                    return "successful"; 
            }
            catch (Exception ex) 
            { 
                return ex.Message;
            }
            

            
            
        }
    }
}
