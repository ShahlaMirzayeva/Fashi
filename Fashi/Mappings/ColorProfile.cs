using AutoMapper;
using Fashi.Areas.Admin.ViewModels.ColorVm;
using Fashi.Dtos.Color;
using Fashi.Models;


namespace Fashi.Mappings
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<CreateColorVm, ColorCreateDto>();
            CreateMap<UpdateColorVm, ColorUpdateDto>();
            
            CreateMap<Color, ColorDto>();
            CreateMap<ColorCreateDto, Color>();
            CreateMap<ColorUpdateDto, Color>();
        }
    }
}
