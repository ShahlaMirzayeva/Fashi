using Fashi.Models;
using Fashi.Repositories.ColorRepo;

namespace Fashi.Services.ColorServ
{
    public class ColorService : IColorService
    {private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task AddColorAsync(Color color)
        {
           await _colorRepository.AddAsync(color);
            await _colorRepository.SaveAsync();

        }

        public async Task DeleteColorAsync(int id)
        {
            await _colorRepository.DeleteAsync(id);
            await _colorRepository.SaveAsync();
        }

        public async Task<IEnumerable<Color>> GetAllColorAsync()
        {
            return await _colorRepository.GetAllAsync();
        }

        public async Task<Color> GetColorByIdAsync(int id)
        {
            return await _colorRepository.GetByIdAsync(id);
        }

        public async Task UpdateColorAsync(Color color)
        {
            await _colorRepository.UpdateAsync(color);
            await _colorRepository.SaveAsync();
        }
    }
}
