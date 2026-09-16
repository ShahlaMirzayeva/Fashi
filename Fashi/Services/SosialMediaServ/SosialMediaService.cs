using AutoMapper;
using Fashi.Dtos.SosialMedia;
using Fashi.Models;
using Fashi.Repositories.SosialMediaRepo;
using Fashi.Services.FileServ;
using System.Linq.Expressions;

namespace Fashi.Services.SosialMediaServ
{
    public class SosialMediaService : ISosialMediaService
    {private readonly ISosialMediaRepository _sosialMediaRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public SosialMediaService(ISosialMediaRepository sosialMediaRepository, IFileService fileService, IMapper mapper)
        {
            _sosialMediaRepository = sosialMediaRepository;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SosialMediaDto>> GetAllSosialMediaAsync()
        {var sosialMedia =await _sosialMediaRepository.GetAllAsync();

           return  _mapper.Map<IEnumerable<SosialMediaDto>>(sosialMedia);
        }

        public async Task<SosialMediaDto> GetSosialMediaByIdAsync(int id)
        {var sosialMedia = await _sosialMediaRepository.GetByIdAsync(id);
            if(sosialMedia == null)
            {
                throw new Exception("Sosial media not found");
            }
            return _mapper.Map<SosialMediaDto>(sosialMedia);
        }

        public async Task AddSosialMediaAsync(SosialMediaCreateDto sosialMediaDto)
        {

      var sosialMedia=_mapper.Map<SosialMedia>(sosialMediaDto);
      if(sosialMediaDto.ImageUrl != null)
      {
          sosialMedia.Image = await _fileService.UploadFileAsync(sosialMediaDto.ImageUrl, "sosial-media");
      }
           await _sosialMediaRepository.AddAsync(sosialMedia);
            await _sosialMediaRepository.SaveAsync();
        }

        public async Task DeleteSosialMediaAsync(int id)
        {var existingSosialMedia =await _sosialMediaRepository.GetByIdAsync(id);
             _fileService.DeleteImage(existingSosialMedia.Image);
           await _sosialMediaRepository.DeleteAsync(id);
            await _sosialMediaRepository.SaveAsync();
        }

        public async Task UpdateSosialMediaAsync(SosialMediaUpdateDto sosialMediaDto)
        {
            var existingSosialMedia = await _sosialMediaRepository.GetByIdAsync(sosialMediaDto.Id);

            _mapper.Map(sosialMediaDto, existingSosialMedia);
          
            if (sosialMediaDto.ImageUrl != null)
            {
                _fileService.DeleteImage(existingSosialMedia.Image);
                existingSosialMedia.Image = await _fileService.UploadFileAsync(sosialMediaDto.ImageUrl, "sosial-media");
            }
            await _sosialMediaRepository.UpdateAsync(existingSosialMedia);
            await _sosialMediaRepository.SaveAsync();
        }

      
    }
}
