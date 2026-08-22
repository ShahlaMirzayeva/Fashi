using Fashi.Models;
using Fashi.Repositories.BenefitRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.BenefitServ
{
    public class BenefitService : IBenefitService
    {private readonly IBenefitRepository _benefitRepository;
        private readonly IFileService _fileService;
        public BenefitService(IBenefitRepository benefitRepository, IFileService fileService)
        {
            _benefitRepository = benefitRepository;
            _fileService = fileService;
        }

        public async Task AddBenefitAsync(Benefit benefit)
        {string iconPath = await _fileService.UploadFileAsync(benefit.IconUrl, "benefits");
            var newBenefit = new Benefit()
            {
                Title = benefit.Title,
                Description = benefit.Description,
                Icon = iconPath
            };


           

            await _benefitRepository.AddAsync(newBenefit);
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

        public async Task<IEnumerable<Benefit>> GetAllBenefitsAsync()
        {
            var benefits = await _benefitRepository.GetAllAsync();
            return benefits;
        }

        public async Task<Benefit> GetBenefitByIdAsync(int id)
        {
            var benefit = await _benefitRepository.GetByIdAsync(id);
            return benefit;
        }
        

        public async Task UpdateBenefitAsync(Benefit benefit)
        {
            var existingBenefit = await _benefitRepository.GetByIdAsync(benefit.Id);
            if (existingBenefit == null)
            {
                throw new ArgumentException("Benefit not found");
            }

            existingBenefit.Title = benefit.Title;
            existingBenefit.Description = benefit.Description;
            _fileService.DeleteImage(existingBenefit.Icon);
            existingBenefit.Icon = await _fileService.UploadFileAsync(benefit.IconUrl, "benefits");
            await _benefitRepository.UpdateAsync(existingBenefit);
            await _benefitRepository.SaveAsync();
        }
    }
}
