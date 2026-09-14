using Fashi.Dtos.DealOfWeek;
using Fashi.Models;

namespace Fashi.Services.DealOfWeekServ
{
    public interface IDealOfWeekService
    {
        Task<IEnumerable<DealOfWeekDto>> GetAllDealOfWeekAsync();
        Task<DealOfWeekDto>GetByIdDealOfWeekAsync(int id);
        Task AddDealOfWeekAsync(DealOfWeekCreateDto dealOfWeekDto);
        Task DeleteDealOfWeekAsync(int id);
        Task UpdateDealOfWeekAsync(DealOfWeekUpdateDto dealOfWeekDto);
    }
}
