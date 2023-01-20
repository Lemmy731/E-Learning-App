using E_Learn.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ErrorController(StoreContext storeContext)
        {
         _storeContext = storeContext;  
        }
        [HttpGet("not found")]  
        public ActionResult NotFoundMethod()
        {
            var category = _storeContext.Category.Find(42);
            if(category == null) return NotFound(new ApiErrorRes(404));
            return Ok(category);
        }
        [HttpGet("server Error")]
        public ActionResult ServerErrorMethod()
        {
            var category = _storeContext.Category.Find(42);
           
            return Ok(category.ToString());
        }
        [HttpGet("BadRequest")]
        public ActionResult BadRequestMethod()
        {
            return BadRequest(new ApiErrorRes(400));
        }
        [HttpGet("BadRequest/{id}")]
        public ActionResult BadIdMethod(int id)
        {
            return Ok();
        }
    }
}
