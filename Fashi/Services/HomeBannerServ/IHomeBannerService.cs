using Fashi.Models;

namespace Fashi.Services.HomeBannerServ
{
    public interface IHomeBannerService
    {
       Task<IEnumerable<HomeBanner>> GetAllHomeBannerAsync();
        Task<HomeBanner> GetByIdHomeBannerAsync(int id);
        Task AddHomeBannerAsync(HomeBanner homeBanner);
        Task DeleteHomeBannerAsync(int id);
        Task UpdateHomeBannerAsync(HomeBanner homeBanner);
    }
}
