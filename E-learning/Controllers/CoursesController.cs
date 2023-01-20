using AutoMapper;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;
using E_Learn.Infrastructure;
using E_Learn.Infrastructure.IRepo;
using E_Learn.Infrastructure.Specification;
using ELearning.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace E_learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        [HttpGet("Get-All-Courses")]
        public async Task<ActionResult> GetAllCourse([FromQuery] CourseParams courseParams)
        {
            try
            {

                var result = await _courseService.GetAllCourse(courseParams); 


                if (result == null)
                {
                    return BadRequest("not item found");

                }
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }



        }
        [HttpGet ("GetCourseById")]
        public async Task<ActionResult> GetCourseById(Guid Id)
        {
            try
            {
                var result = await _courseService.GetCourseById(Id);
                if(result == null)
                {
                    return StatusCode(400, "not item found");
                }
                return Ok(result);  
            }
            catch(Exception ex) { 
                return BadRequest(ex.Message);  
            }
            
              
        }
        [HttpGet("GetCourseByCategory")]
        public IActionResult GetCourseByCategory(int Id)
        {
            try
            {
                var result =  _courseService.GetCourseByCategory(Id);
                if (result == null)
                return BadRequest("no iten found");
                return Ok(result);
                
            }
            catch(Exception ex) 
            { 
               return BadRequest(ex.Message);   
            } 
           
        }

        [HttpPost("AddCategoty")]
        public async Task<IActionResult> AddCategoty(CourseDTO courseDTO)
        {
            try
            {
                var result = await _courseService.AddCourse(courseDTO);
                if(result.Contains("successful"))
                    return Ok(result);
                return BadRequest(result);  
            }
            catch(Exception ex) 
            { 
              return BadRequest(ex.Message);    
            }
            

             

        }
    }
}
