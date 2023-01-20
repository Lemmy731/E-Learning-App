using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Entity.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        
    }
}
