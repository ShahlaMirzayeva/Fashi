using AutoMapper;
using Fashi.Areas.Admin.ViewModels.GenderVm;
using Fashi.Dtos.Gender;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<CreateGenderVm, GenderCreateDto>();
            CreateMap<UpdateGenderVm, GenderUpdateDto>();



            CreateMap<Gender, GenderDto>();
            CreateMap<GenderCreateDto, Gender>();
            CreateMap<GenderUpdateDto, Gender>();
        }
    }
}
