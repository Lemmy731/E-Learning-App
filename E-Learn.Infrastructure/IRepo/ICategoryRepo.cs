using E_Learn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.IRepo
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<IEnumerable<Category>> GetCategoryById(int id);
    }
}
