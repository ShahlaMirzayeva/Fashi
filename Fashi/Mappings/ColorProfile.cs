using AutoMapper;
using Fashi.Dtos.Color;
using Fashi.Models;


namespace Fashi.Mappings
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>();
            CreateMap<ColorCreateDto, Color>();
            CreateMap<ColorUpdateDto, Color>();
        }
    }
}
