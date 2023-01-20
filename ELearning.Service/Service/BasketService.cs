using E_Learn.Entity.Models;
using ELearning.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Service.Service
{
    public class BasketService: IBasketService
    {
        Basket basket = new Basket();
        public void AddCourseItem(Course course)
        {
          
            if(basket.Items.All(item => item.CourseId != course.Id))
            {
                basket.Items.Add(new BasketItem { Course = course });
            }
        }

        public void RemoveCourse(Guid courseId) 
        {
           var course = basket.Items.FirstOrDefault(item => item.CourseId == courseId);
            basket.Items.Remove(course);   
        }
    }
}
