using Fashi.Models;

namespace Fashi.Services.ColorServ
{
    public interface IColorService
    {Task<IEnumerable<Color>> GetAllColorAsync();
        Task<Color> GetColorByIdAsync(int id);
        Task AddColorAsync(Color color);
        Task DeleteColorAsync(int id);
        Task UpdateColorAsync(Color color);
    }
}
