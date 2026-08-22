using Fashi.Data;
using Fashi.Models;
using Fashi.Repositories.HomeBannerRepo;

namespace Fashi.Services.HomeBannerServ
{
    public class HomeBannerService : IHomeBannerService
    {
        private readonly IHomeBannerRepository _bannerRepository;
        public HomeBannerService(IHomeBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task AddHomeBannerAsync(HomeBanner homeBanner)
        {var banner = new HomeBanner
        {
            Title = homeBanner.Title,
            LittleTitle = homeBanner.LittleTitle,
            Description = homeBanner.Description,
            Image = homeBanner.Image,
            Photo = homeBanner.Photo
        };
            await _bannerRepository.AddAsync(banner);
            await _bannerRepository.SaveAsync();
           
        }

        public async Task DeleteHomeBannerAsync(int id)
        {var banner = _bannerRepository.GetByIdAsync(id);
            if (banner == null)
            {
                throw new Exception("Banner not found");
            }
            await _bannerRepository.DeleteAsync(id);
          await _bannerRepository.SaveAsync();
        }

        public async Task<IEnumerable<HomeBanner>> GetAllHomeBannerAsync()
        {var banners =await _bannerRepository.GetAllAsync();
            return banners;
        }

        public async Task<HomeBanner> GetByIdHomeBannerAsync(int id)
        {var banner =await _bannerRepository.GetByIdAsync(id);
           return banner;
        }

        public async Task UpdateHomeBannerAsync(HomeBanner homeBanner)
        {
            var banner = await _bannerRepository.GetByIdAsync(homeBanner.Id);
            if (banner == null)
            {
                throw new Exception("Banner not found");
            }
            banner.Title = homeBanner.Title;
            banner.LittleTitle = homeBanner.LittleTitle;
            banner.Description = homeBanner.Description;
            banner.Image = homeBanner.Image;
            banner.Photo = homeBanner.Photo;
            await _bannerRepository.UpdateAsync(banner);
            await _bannerRepository.SaveAsync();
        }
    }
}
