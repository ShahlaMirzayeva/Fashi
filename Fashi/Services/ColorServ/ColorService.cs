using AutoMapper;
using Fashi.Dtos.Color;
using Fashi.Models;
using Fashi.Repositories.ColorRepo;

namespace Fashi.Services.ColorServ
{
    public class ColorService : IColorService
    {private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;  

        public ColorService(IColorRepository colorRepository,IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task AddColorAsync(ColorCreateDto colorDto)
        {
            var color = _mapper.Map<Color>(colorDto);
            await _colorRepository.AddAsync(color);
            await _colorRepository.SaveAsync();

        }

        public async Task DeleteColorAsync(int id)
        {
            await _colorRepository.DeleteAsync(id);
            await _colorRepository.SaveAsync();
        }

        public async Task<IEnumerable<ColorDto>> GetAllColorAsync()
        {
           var color= await _colorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ColorDto>>(color);
        }

        public async Task<Color> GetColorByIdAsync(int id)
        {
            return await _colorRepository.GetByIdAsync(id);
        }

        public async Task UpdateColorAsync(ColorUpdateDto colorDto)
        {
            var color = _mapper.Map<Color>(colorDto);
            await _colorRepository.UpdateAsync(color);
            await _colorRepository.SaveAsync();
        }
    }
}
