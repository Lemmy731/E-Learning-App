using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_learning.Controllers
{

    [Route("redirect/{code}")]
   

    public class RedirectController : ControllerBase
    {
        [HttpGet]  
        //display error 404 when an unknown endpoint is called
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiErrorRes(code));
        }
    }
}
