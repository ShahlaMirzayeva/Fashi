using Fashi.Models;

namespace Fashi.Services.BenefitServ
{
    public interface IBenefitService
    {
        Task<IEnumerable<Benefit>> GetAllBenefitsAsync();
        Task<Benefit> GetBenefitByIdAsync(int id);
        Task AddBenefitAsync(Benefit benefit);
        Task DeleteBenefitAsync(int id);
        Task UpdateBenefitAsync(Benefit benefit);
    }
}
