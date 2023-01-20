using E_Learn.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Entity.DTO
{
    public class BasketDTO
    {
        public string ClientId { get; set; }

        public List<BasketItemDTO> Items { get; set; }      
    }
}
