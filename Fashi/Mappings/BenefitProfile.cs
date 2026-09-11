using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BenefitVm;
using Fashi.Areas.Admin.ViewModels.ColorVm;
using Fashi.Dtos.Benefit;
using Fashi.Dtos.Color;
using Fashi.Dtos.Gender;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class BenefitProfile:Profile
    {
        public BenefitProfile()
        {
            CreateMap<CreateBenefitVm, BenefitCreateDto>();
            CreateMap<UpdateBenefitVm, BenefitUpdateDto>();
            CreateMap<BenefitDto, UpdateBenefitVm>();
            CreateMap<BenefitUpdateDto, Benefit>()
    .ForMember(dest => dest.Icon, opt => opt.Ignore());


            CreateMap<Benefit, BenefitDto>();
            CreateMap<BenefitCreateDto, Benefit>();
    
        }
    }
}
