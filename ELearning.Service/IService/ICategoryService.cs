using E_Learn.Entity;
using E_Learn.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Service.IService
{
    public interface ICategoryService
    {
        Task <IEnumerable<CategoriesDTO>> GetAllCategory();
        Task <CategoryDTO> GetCategoryById(int id);    
    }
}
