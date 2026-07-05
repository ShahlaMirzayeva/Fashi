using AutoMapper;
using Fashi.Dtos.Category;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.GenderName, opt => opt.MapFrom(s => s.Gender.Name));
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
              
        }
    }
}
