using AutoMapper;
using Fashi.Areas.Admin.ViewModels.CategoryBannerVm;
using Fashi.Areas.Admin.ViewModels.SosialMediaVm;
using Fashi.Dtos.CategoryBanner;
using Fashi.Dtos.SosialMedia;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class SosialMediaProfile:Profile
    {
        public SosialMediaProfile()
        {
            CreateMap<CreateSosialMediaVm, SosialMediaCreateDto>();
            CreateMap<UpdateSosialMediaVm, SosialMediaUpdateDto>();
            CreateMap<SosialMediaDto, UpdateSosialMediaVm>();
            CreateMap<SosialMediaUpdateDto, SosialMedia>()
    .ForMember(dest => dest.Image, opt => opt.Ignore());


            CreateMap<SosialMedia, SosialMediaDto>();
            CreateMap<SosialMediaCreateDto, SosialMedia>();
        }
    }
}
