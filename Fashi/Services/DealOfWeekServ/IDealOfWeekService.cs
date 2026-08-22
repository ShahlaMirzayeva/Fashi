using Fashi.Models;

namespace Fashi.Services.DealOfWeekServ
{
    public interface IDealOfWeekService
    {
        Task<IEnumerable<DealOfWeek>> GetAllDealOfWeekAsync();
        Task<DealOfWeek>GetByIdDealOfWeekAsync(int id);
        Task AddDealOfWeekAsync(DealOfWeek dealOfWeek);
        Task DeleteDealOfWeekAsync(int id);
        Task UpdateDealOfWeekAsync(DealOfWeek dealOfWeek);
    }
}
