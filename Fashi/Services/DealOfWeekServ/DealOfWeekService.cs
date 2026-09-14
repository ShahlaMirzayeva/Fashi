using AutoMapper;
using Fashi.Dtos.DealOfWeek;
using Fashi.Models;
using Fashi.Repositories.DealOfWeekRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.DealOfWeekServ
{
    public class DealOfWeekService : IDealOfWeekService
    {private readonly IDealOfWeekRepository _dealOfWeekRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public DealOfWeekService(IDealOfWeekRepository dealOfWeekRepository, IMapper mapper, IFileService fileService)
        {
            _dealOfWeekRepository = dealOfWeekRepository;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task AddDealOfWeekAsync(DealOfWeekCreateDto dealOfWeekDto)
        {
         var deal = _mapper.Map<DealOfWeek>(dealOfWeekDto);
            if (dealOfWeekDto.Photo != null)
            {
                var imagePath = await _fileService.UploadFileAsync(dealOfWeekDto.Photo, "images/dealofweek");
                deal.Image = imagePath;
            }
            await _dealOfWeekRepository.AddAsync(deal);
            await _dealOfWeekRepository.SaveAsync();
        }

        public async Task DeleteDealOfWeekAsync(int id)
        {
         
            await _dealOfWeekRepository.DeleteAsync(id);
            await _dealOfWeekRepository.SaveAsync();
          
        }

        public async Task<IEnumerable<DealOfWeekDto>> GetAllDealOfWeekAsync()
        {
           var deals =await _dealOfWeekRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DealOfWeekDto>>(deals);
        }

        public async Task<DealOfWeekDto> GetByIdDealOfWeekAsync(int id)
        {
            var deal = await _dealOfWeekRepository.GetByIdAsync(id);
            if (deal == null)
            {
                throw new Exception("Deal of the week not found");
            }
            return _mapper.Map<DealOfWeekDto>(deal);
        }

        public async Task UpdateDealOfWeekAsync(DealOfWeekUpdateDto dealOfWeekDto)
        {
            var deal = await _dealOfWeekRepository.GetByIdAsync(dealOfWeekDto.Id);
            if (deal == null)
            {
                throw new Exception("Deal of the week not found");
            }

            _mapper.Map(dealOfWeekDto, deal);

            if(dealOfWeekDto.Photo!= null)
            {
                _fileService.DeleteImage(deal.Image);
                var imagePath = await _fileService.UploadFileAsync(dealOfWeekDto.Photo, "images/dealofweek");
               
            }

            await _dealOfWeekRepository.UpdateAsync(deal);
            await _dealOfWeekRepository.SaveAsync();
        }
      
    }
}
