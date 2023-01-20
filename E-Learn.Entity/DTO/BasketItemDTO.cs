using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Entity.DTO
{
    public class BasketItemDTO
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Instructor { get; set; }
       

    }
}
