using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BenefitVm;
using Fashi.Areas.Admin.ViewModels.BlogCategoryVm;
using Fashi.Dtos.Benefit;
using Fashi.Dtos.BlogCategory;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class BlogCategoryProfile:Profile
    {
        public BlogCategoryProfile()
        {
            CreateMap<CreateBlogCategoryVm, BlogCategoryCreateDto>();
            CreateMap<UpdateBlogCategoryVm, BlogCategoryUpdateDto>();
            CreateMap<BlogCategoryDto, UpdateBlogCategoryVm>();
            CreateMap<BlogCategoryUpdateDto, BlogCategory>();

            CreateMap<BlogCategory, BlogCategoryDto>();
            CreateMap<BlogCategoryCreateDto, BlogCategory>();
        }
    }
}
