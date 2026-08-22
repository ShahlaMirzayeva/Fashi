using Fashi.Models;
using Fashi.Repositories.SosialMediaRepo;
using Fashi.Services.FileServ;
using System.Linq.Expressions;

namespace Fashi.Services.SosialMediaServ
{
    public class SosialMediaService : ISosialMediaService
    {private readonly ISosialMediaRepository _sosialMediaRepository;
        private readonly IFileService _fileService;
        public SosialMediaService(ISosialMediaRepository sosialMediaRepository, IFileService fileService)
        {
            _sosialMediaRepository = sosialMediaRepository;
            _fileService = fileService;
        }
        public async Task<IEnumerable<SosialMedia>> GetAllSosialMediaAsync()
        {var sosialMediaList =await _sosialMediaRepository.GetAllAsync();

           return sosialMediaList;
        }

        public async Task<SosialMedia> GetSosialMediaByIdAsync(int id)
        {var sosialMedia = await _sosialMediaRepository.GetByIdAsync(id);
            return sosialMedia;
        }

        public async Task AddSosialMediaAsync(SosialMedia sosialMedia)
        {string imageUrl = await _fileService.UploadFileAsync(sosialMedia.ImageUrl,"sosial-media");

            var newSosialMedia = new SosialMedia
        {
            SosialMediaLink = sosialMedia.SosialMediaLink,
            Image =imageUrl,
            Icon = sosialMedia.Icon
        };
           await _sosialMediaRepository.AddAsync(newSosialMedia);
            await _sosialMediaRepository.SaveAsync();
        }

        public async Task DeleteSosialMediaAsync(int id)
        {var existingSosialMedia =await _sosialMediaRepository.GetByIdAsync(id);
             _fileService.DeleteImage(existingSosialMedia.Image);
           await _sosialMediaRepository.DeleteAsync(id);
            await _sosialMediaRepository.SaveAsync();
        }

        public async Task UpdateSosialMediaAsync(SosialMedia sosialMedia)
        {
            var existingSosialMedia = await _sosialMediaRepository.GetByIdAsync(sosialMedia.Id);
            existingSosialMedia.SosialMediaLink = sosialMedia.SosialMediaLink;
            existingSosialMedia.Icon = sosialMedia.Icon;
            if (sosialMedia.ImageUrl != null)
            {
                _fileService.DeleteImage(existingSosialMedia.Image);
                existingSosialMedia.Image = await _fileService.UploadFileAsync(sosialMedia.ImageUrl, "sosial-media");
            }
            await _sosialMediaRepository.SaveAsync();
        }
        
    }
}
