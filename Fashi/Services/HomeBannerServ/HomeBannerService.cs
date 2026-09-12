using AutoMapper;
using Fashi.Dtos.HomeBanner;
using Fashi.Models;
using Fashi.Repositories.HomeBannerRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.HomeBannerServ
{
    public class HomeBannerService : IHomeBannerService
    {
        private readonly IHomeBannerRepository _bannerRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public HomeBannerService(IHomeBannerRepository bannerRepository, IMapper mapper, IFileService fileService)
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task AddHomeBannerAsync(HomeBannerCreateDto homeBannerDto)
        {
            var homeBanner = _mapper.Map<HomeBanner>(homeBannerDto);
            if (homeBannerDto.Photo != null)
            {
                homeBanner.Image = await _fileService.UploadFileAsync(homeBannerDto.Photo, "home-banners");
            }
            await _bannerRepository.AddAsync(homeBanner);
            await _bannerRepository.SaveAsync();

        }

        public async Task DeleteHomeBannerAsync(int id)
        {
            var banner = _bannerRepository.GetByIdAsync(id);
            if (banner == null)
            {
                throw new Exception("Banner not found");
            }
            _fileService.DeleteImage((await banner).Image);
            await _bannerRepository.DeleteAsync(id);
            await _bannerRepository.SaveAsync();
        }

        public async Task<IEnumerable<HomeBannerDto>> GetAllHomeBannerAsync()
        {
            var banners = await _bannerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HomeBannerDto>>(banners);
        }

        public async Task<HomeBannerDto> GetByIdHomeBannerAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            return _mapper.Map<HomeBannerDto>(banner);
        }

        public async Task UpdateHomeBannerAsync(HomeBannerUpdateDto homeBannerDto)
        {
            var banner = await _bannerRepository.GetByIdAsync(homeBannerDto.Id);
            if (banner == null)
            {
                throw new Exception("Banner not found");
            }
    _mapper.Map(homeBannerDto, banner);
            if(homeBannerDto.Photo != null)
            {
                _fileService.DeleteImage(banner.Image);
                banner.Image = await _fileService.UploadFileAsync(homeBannerDto.Photo, "home-banners");
            }
            await _bannerRepository.UpdateAsync(banner);
            await _bannerRepository.SaveAsync();
        }
    }
}
