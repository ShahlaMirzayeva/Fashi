using Fashi.Models;

namespace Fashi.Services.DiscoverServ
{
    public interface IDiscoverService
    {
        Task<IEnumerable<Discover>> GetAllDiscoversAsync();
        Task<Discover> GetDiscoverByIdAsync(int id);
        Task AddDiscoverAsync(Discover discover);
        Task UpdateDiscoverAsync(Discover discover);
        Task DeleteDiscoverAsync(int id);
    }
}
