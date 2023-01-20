using E_Learn.Entity.Models;
using E_Learn.Infrastructure.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Repo
{
    public class BasketRepo: IBasketRepo
    {
        private readonly StoreContext _storeContext;
        public BasketRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;   
        }
        //public async Task<Queryable> GetBasket()
        //{
        //    var response = _storeContext.Baskets
        //        .Include(b => b.Items)
        //        .ThenInclude(i => i.Course);
        //    return response;
       
        //}
        
    }
}
