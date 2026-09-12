using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BenefitVm;
using Fashi.Areas.Admin.ViewModels.HomeBannerVm;
using Fashi.Dtos.Benefit;
using Fashi.Dtos.HomeBanner;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class HomeBannerProfile:Profile
    {
        public HomeBannerProfile()
        {
            CreateMap<CreateHomeBannerVm, HomeBannerCreateDto>();
            CreateMap<UpdateHomeBannerVm, HomeBannerUpdateDto>();
            CreateMap<HomeBannerDto, UpdateHomeBannerVm>();
            CreateMap<HomeBannerUpdateDto, HomeBanner>()
    .ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<HomeBanner, HomeBannerDto>();
            CreateMap<HomeBannerCreateDto, HomeBanner>();
        }
    }
}
