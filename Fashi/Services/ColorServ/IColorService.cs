using Fashi.Dtos.Color;
using Fashi.Models;

namespace Fashi.Services.ColorServ
{
    public interface IColorService
    {Task<IEnumerable<ColorDto>> GetAllColorAsync();
        Task<Color> GetColorByIdAsync(int id);
        Task AddColorAsync(ColorCreateDto colorDto);
        Task DeleteColorAsync(int id);
        Task UpdateColorAsync(ColorUpdateDto colorDto);
    }
}
