using Fashi.Models;

namespace Fashi.Services.SaleServ
{
    public interface ISaleService
    {
        Task CreateSaleAsync(string userId);
    }
}
