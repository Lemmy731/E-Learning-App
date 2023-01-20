using E_Learn.Infrastructure.Specification;
using ELearning.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;     
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var result = await _categoryService.GetAllCategory();
                if(result.Any())
                return Ok(result); 
                return BadRequest("no item found");  
            }
            catch (Exception ex) 
            {
               return BadRequest(ex.Message);
            }
           
            
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                
              var result = await _categoryService.GetCategoryById(id);
                if (result != null)
                return Ok(result);
                return BadRequest("no item found");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);      
            }
        }
    }
}
