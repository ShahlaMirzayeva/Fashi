using AutoMapper;
using Fashi.Areas.Admin.ViewModels.CategoryVm;
using Fashi.Dtos.Category;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryVm,CategoryCreateDto>();
            CreateMap<UpdateCategoryVm, CategoryUpdateDto>();


            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.GenderName, opt => opt.MapFrom(s => s.Gender.Name));
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
              
        }
    }
}
