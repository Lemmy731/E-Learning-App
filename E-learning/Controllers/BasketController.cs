using AutoMapper;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;
using E_Learn.Infrastructure;
using ELearning.Service.IService;
using ELearning.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace E_learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        BasketService basketService = new BasketService();

        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public BasketController(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;   
        }
        [HttpGet]
        public async Task<ActionResult<BasketDTO>> GetBasket()
        {
            try
            {
                var basket = await ExtractBasket();
                    
                if (basket == null)
                    return NotFound(new ApiErrorRes(404, "No Item Found"));
                var basketResponse = _mapper.Map<Basket, BasketDTO>(basket);
                return Ok(basketResponse);
            }
            catch (Exception ex)
            {
               return NotFound(ex.Message);   
                
            }
        }


        [HttpPost]
        public async Task<ActionResult<BasketDTO>> AddItemToBasket(Guid courseId)
        {
            try
            {
                
                var basket = await ExtractBasket();
                if (basket == null) basket = CreateBasket();
                var course = await _storeContext.Courses.FindAsync(courseId);
                if (course == null) return NotFound(new ApiErrorRes(404));
                basketService.AddCourseItem(course);

                var result = await _storeContext.SaveChangesAsync()  ;
                var basketResponse = _mapper.Map<Basket, BasketDTO>(basket);
                if (result == null) return basketResponse;
                return BadRequest(new ApiErrorRes(400, "Problem saving items to basket"));

                

                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
           

        }
        [HttpDelete]
        public async Task<ActionResult> RemoveItem(Guid courseId)
        {
            
            var basket = ExtractBasket();
            if (basket == null) return NotFound(new ApiErrorRes(404, "No item found"));
            basketService.RemoveCourse(courseId);
            var result = await _storeContext.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ApiErrorRes(400, "Problem removing the item from the basket"));
        }

        private Basket CreateBasket()
        {
            var clientId = Guid .NewGuid().ToString();
            var options = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(10) };
            Response.Cookies.Append("clientId", clientId, options);
            var basket = new Basket { ClientId = clientId };
            _storeContext.Baskets.Add(basket);
            return basket;

        }

        private async Task<Basket> ExtractBasket()
        {
            
            return await _storeContext.Baskets
           .Include(c => c.Items)
           .ThenInclude(c => c.Course)
           .FirstOrDefaultAsync(x => x.ClientId == Request.Cookies["clientId"]);
        }
    }
}
