using Fashi.Models;
using Fashi.Repositories.DealOfWeekRepo;

namespace Fashi.Services.DealOfWeekServ
{
    public class DealOfWeekService : IDealOfWeekService
    {private readonly IDealOfWeekRepository _dealOfWeekRepository;
        public DealOfWeekService(IDealOfWeekRepository dealOfWeekRepository)
        {
            _dealOfWeekRepository = dealOfWeekRepository    ;
        }
        public async Task AddDealOfWeekAsync(DealOfWeek dealOfWeek)
        {
            var deal = new DealOfWeek
            {
                ProductName = dealOfWeek.ProductName,
                Title = dealOfWeek.Title,
                Description = dealOfWeek.Description,
                DealofTime = dealOfWeek.DealofTime,
                Price = dealOfWeek.Price,
                Image = dealOfWeek.Image
            };
         await _dealOfWeekRepository.AddAsync(deal);
            await _dealOfWeekRepository.SaveAsync();
        }

        public async Task DeleteDealOfWeekAsync(int id)
        {
         
            await _dealOfWeekRepository.DeleteAsync(id);
            await _dealOfWeekRepository.SaveAsync();
          
        }

        public Task<IEnumerable<DealOfWeek>> GetAllDealOfWeekAsync()
        {
           var deals = _dealOfWeekRepository.GetAllAsync();
            return deals;
        }

        public async Task<DealOfWeek> GetByIdDealOfWeekAsync(int id)
        {
            var deal = await _dealOfWeekRepository.GetByIdAsync(id);
            if (deal == null)
            {
                throw new Exception("Deal of the week not found");
            }
            return deal;
        }

        public async Task UpdateDealOfWeekAsync(DealOfWeek dealOfWeek)
        {
            var deal = await _dealOfWeekRepository.GetByIdAsync(dealOfWeek.Id);
            if (deal == null)
            {
                throw new Exception("Deal of the week not found");
            }

            deal.ProductName = dealOfWeek.ProductName;
            deal.Title = dealOfWeek.Title;
            deal.Description = dealOfWeek.Description;
            deal.DealofTime = dealOfWeek.DealofTime;
            deal.Price = dealOfWeek.Price;
            deal.Image = dealOfWeek.Image;

            await _dealOfWeekRepository.UpdateAsync(deal);
            await _dealOfWeekRepository.SaveAsync();
        }
      
    }
}
