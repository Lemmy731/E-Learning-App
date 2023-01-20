using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Entity.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
