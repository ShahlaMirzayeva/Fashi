using Fashi.Dtos.Benefit;
using Fashi.Models;

namespace Fashi.Services.BenefitServ
{
    public interface IBenefitService
    {
        Task<IEnumerable<BenefitDto>> GetAllBenefitsAsync();
        Task<BenefitDto> GetBenefitByIdAsync(int id);
        Task AddBenefitAsync(BenefitCreateDto benefitDto);
        Task DeleteBenefitAsync(int id);
        Task UpdateBenefitAsync(BenefitUpdateDto benefitDto);
    }
}
