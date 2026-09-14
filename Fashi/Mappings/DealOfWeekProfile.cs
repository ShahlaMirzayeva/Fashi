using AutoMapper;
using Fashi.Areas.Admin.ViewModels.CategoryBannerVm;
using Fashi.Areas.Admin.ViewModels.DealOfWeek;
using Fashi.Dtos.CategoryBanner;
using Fashi.Dtos.DealOfWeek;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class DealOfWeekProfile:Profile
    {
        public DealOfWeekProfile()
        {
            CreateMap<CreateDealOfWeekVm, DealOfWeekCreateDto>();
            CreateMap<UpdateDealOfWeekVm, DealOfWeekUpdateDto>();
            CreateMap<DealOfWeekDto, UpdateDealOfWeekVm>();
            CreateMap<DealOfWeekUpdateDto, DealOfWeek>()
    .ForMember(dest => dest.Image, opt => opt.Ignore());



            CreateMap<DealOfWeek, DealOfWeekDto>();
            CreateMap<DealOfWeekCreateDto, DealOfWeek>();
        }
    }
}
