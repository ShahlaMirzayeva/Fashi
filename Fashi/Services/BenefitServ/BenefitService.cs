using AutoMapper;
using Fashi.Dtos.Benefit;
using Fashi.Models;
using Fashi.Repositories.BenefitRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.BenefitServ
{
    public class BenefitService : IBenefitService
    {private readonly IBenefitRepository _benefitRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public BenefitService(IBenefitRepository benefitRepository, IFileService fileService, IMapper mapper)
        {
            _benefitRepository = benefitRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task AddBenefitAsync(BenefitCreateDto benefitDto)
        {var benefit = _mapper.Map<Benefit>(benefitDto);
          if(benefitDto.IconUrl != null)
            {
                benefit.Icon = await _fileService.UploadFileAsync(benefitDto.IconUrl, "benefits");
            }





            await _benefitRepository.AddAsync(benefit);
            await _benefitRepository.SaveAsync();    
        }

        public async Task DeleteBenefitAsync(int id)
        {var existingBenefit = await _benefitRepository.GetByIdAsync(id);
            if (existingBenefit == null)
            {
                throw new ArgumentException("Benefit not found");
            }
            _fileService.DeleteImage(existingBenefit.Icon);
            await _benefitRepository.DeleteAsync(id);
            await _benefitRepository.SaveAsync();
        }

        public async Task<IEnumerable<BenefitDto>> GetAllBenefitsAsync()
        {
            var benefits = await _benefitRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BenefitDto>>(benefits);
        }

        public async Task<BenefitDto> GetBenefitByIdAsync(int id)
        {
            var benefit = await _benefitRepository.GetByIdAsync(id);
            return _mapper.Map<BenefitDto>(benefit);
        }
        

        public async Task UpdateBenefitAsync(BenefitUpdateDto benefitDto)
        {
            var existingBenefit = await _benefitRepository.GetByIdAsync(benefitDto.Id);
            if (existingBenefit == null)
            {
                throw new ArgumentException("Benefit not found");
            }
            _mapper.Map(benefitDto, existingBenefit);

            if (benefitDto.IconUrl != null)
            {
                _fileService.DeleteImage(existingBenefit.Icon);
                existingBenefit.Icon = await _fileService.UploadFileAsync(benefitDto.IconUrl, "benefits");
            }
          
            await _benefitRepository.UpdateAsync(existingBenefit);
            await _benefitRepository.SaveAsync();
        }
    }
}
