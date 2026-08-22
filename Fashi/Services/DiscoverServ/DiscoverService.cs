using Fashi.Models;
using Fashi.Repositories.DiscoverRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.DiscoverServ
{
    public class DiscoverService : IDiscoverService
    {private readonly IDiscoverRepository _discoverRepository;
        private readonly IFileService _fileService;

        public DiscoverService(IDiscoverRepository discoverRepository, IFileService fileService)
        {
            _discoverRepository = discoverRepository;
            _fileService = fileService;
        }

        public async Task AddDiscoverAsync(Discover discover)
        {string imagePath = await _fileService.UploadFileAsync(discover.Photo, "discover");
            var discoverRepo = new Discover
            {
              Name = discover.Name,
                Button = discover.Button,
                Image = imagePath
            };
           await _discoverRepository.AddAsync(discoverRepo);
            await _discoverRepository.SaveAsync();
        }

        public async Task DeleteDiscoverAsync(int id)
        {
            var existingDiscover = await _discoverRepository.GetByIdAsync(id);
            if (existingDiscover == null)
            {
                throw new ArgumentException("Discover not found");
            }
            _fileService.DeleteImage(existingDiscover.Image);
            await _discoverRepository.DeleteAsync(id);
            await _discoverRepository.SaveAsync();
        }

        public async Task<IEnumerable<Discover>> GetAllDiscoversAsync()
        {var discovers = await _discoverRepository.GetAllAsync();
            return discovers;
          
        }

        public async Task<Discover> GetDiscoverByIdAsync(int id)
        {
            var discover = await _discoverRepository.GetByIdAsync(id);
            return discover;
        }

        public async Task UpdateDiscoverAsync(Discover discover)
        {
            var existingDiscover = await _discoverRepository.GetByIdAsync(discover.Id);
            if (existingDiscover == null)
            {
                throw new ArgumentException("Discover not found");
            }

            existingDiscover.Name = discover.Name;
            existingDiscover.Button = discover.Button;
            _fileService.DeleteImage(existingDiscover.Image);
            existingDiscover.Image = await _fileService.UploadFileAsync(discover.Photo, "discover");
            await _discoverRepository.UpdateAsync(existingDiscover);
            await _discoverRepository.SaveAsync();
        }
    }
}
