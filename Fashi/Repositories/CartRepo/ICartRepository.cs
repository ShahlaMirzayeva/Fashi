using Fashi.Models;

namespace Fashi.Repositories.CartRepo
{
    public interface ICartRepository:IRepository<Cart>
    {
        Task<Cart?> GetByUserIdAsync(string userId);
    }
}
