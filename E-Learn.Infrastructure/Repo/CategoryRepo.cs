using E_Learn.Entity;
using E_Learn.Infrastructure.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly StoreContext _storeContext;

        public CategoryRepo(StoreContext storeContext )
        {
           _storeContext = storeContext;    
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {

            var response = await _storeContext.Category.Include(x => x.Courses)
                .ToListAsync();
            try
            {
               
                if ( response == null) 
                {
                    return response;
                }
                return response;
            }
            catch ( Exception ex ) 
            {
                var no = ex.Message;
           
            }
            return response;
          
        }

        public async Task<IEnumerable<Category>> GetCategoryById(int id)
        {
            var response =  _storeContext.Category.Include(c => c.Courses)
                .Where(x => x.Id==id);
            try
            {
                if (response.Any())
                    return response;
                return response;

            } 
            catch ( Exception ex ) 
            { 
               var cau = ex.Message;    
            }
            return response;
        }
    }
}
