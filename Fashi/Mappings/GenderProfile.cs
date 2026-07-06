using AutoMapper;
using Fashi.Dtos.Gender;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>();
            CreateMap<GenderCreateDto, Gender>();
            CreateMap<GenderUpdateDto, Gender>();
        }
    }
}
