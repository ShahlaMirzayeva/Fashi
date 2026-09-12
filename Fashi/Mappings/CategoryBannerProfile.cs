using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BenefitVm;
using Fashi.Areas.Admin.ViewModels.CategoryBannerVm;
using Fashi.Dtos.Benefit;
using Fashi.Dtos.CategoryBanner;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class CategoryBannerProfile:Profile
    {
        public CategoryBannerProfile()
        {
            CreateMap<CreateCategoryBannerVm, CategoryBannerCreateDto>();
            CreateMap<UpdateCategoryBannerVm, CategoryBannerUpdateDto>();
            CreateMap<CategoryBannerDto, UpdateCategoryBannerVm>();
            CreateMap<CategoryBannerUpdateDto, CategoryBanner>()
    .ForMember(dest => dest.Image, opt => opt.Ignore());


            CreateMap<Benefit, BenefitDto>();
            CreateMap<BenefitCreateDto, Benefit>();
        }
    }
}
