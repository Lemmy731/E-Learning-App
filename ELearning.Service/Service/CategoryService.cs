using AutoMapper;
using E_Learn.Entity;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;
using E_Learn.Infrastructure.IRepo;
using E_Learn.Infrastructure.Specification;
using ELearning.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Service.Service
{
    
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public readonly IMapper _mapper;
        private readonly IGenericRepo<Category> _genericRepo;

        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper, IGenericRepo<Category>genericRepo)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _genericRepo = genericRepo; 
        }



        public async Task<IEnumerable<CategoriesDTO>> GetAllCategory()
        {
            //var response = await _categoryRepo.GetAllCategory();
            var response = await _genericRepo.ListAllAsync();
           var res =  _mapper.Map<IEnumerable<Category>, IEnumerable<CategoriesDTO>>(response);
            try
            {
                if(res.Any())
                return res;
                return res;
            }
            catch (Exception ex) 
            {
                var imm = ex.Message;
            }
            return res;    
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            //var response = await _categoryRepo.GetCategoryById(id);
            var spec = new CategoryWithCourseSpecification(id);
            var response = await _genericRepo.GetEntityWithSpec(spec);  
           var res = _mapper.Map<Category,CategoryDTO>(response);
            try
            {
                if (res==null)
                return res;
                return res;
            }
            catch(Exception ex) 
            {
                var res1 = ex.Message;
            }
            return res;
            
        }
    }
}
