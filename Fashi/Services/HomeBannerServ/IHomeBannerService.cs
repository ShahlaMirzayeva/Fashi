using Fashi.Dtos.HomeBanner;
using Fashi.Models;

namespace Fashi.Services.HomeBannerServ
{
    public interface IHomeBannerService
    {
       Task<IEnumerable<HomeBannerDto>> GetAllHomeBannerAsync();
        Task<HomeBannerDto> GetByIdHomeBannerAsync(int id);
        Task AddHomeBannerAsync(HomeBannerCreateDto  homeBannerDto);
        Task DeleteHomeBannerAsync(int id);
        Task UpdateHomeBannerAsync(HomeBannerUpdateDto homeBannerDto);
    }
}
