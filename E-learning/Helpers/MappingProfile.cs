using AutoMapper;
using E_Learn.Entity;
using E_Learn.Entity.DTO;
using E_Learn.Entity.Models;

namespace E_learning.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>()
            .ForMember(c => c.Category, o => o.MapFrom(x => x.Category.Id));
                
            //CreateMap<Learning, LearningDTO>();
            //CreateMap<Requirement, RequirementDTO>();

            //CreateMap<Category, CategoryDTO>();
            //CreateMap<Category, CategoriesDTO>();
            //CreateMap<Basket, BasketDTO>();
            //CreateMap<BasketItem, BasketItemDTO>()
            //.ForMember(c => c.CourseId, c => c.MapFrom(x => x.CourseId))
            //.ForMember(c => c.Title, c => c.MapFrom(x => x.Course.Title))
            //.ForMember(c => c.Price, c => c.MapFrom(x => x.Course.Price))
            //.ForMember(c => c.Image, c => c.MapFrom(x => x.Course.Image))
            //.ForMember(c => c.Instructor, c => c.MapFrom(x => x.Course.Instructor));

        }
    }
}
