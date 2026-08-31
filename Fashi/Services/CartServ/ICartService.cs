using Fashi.ViewModels.CartVm;

namespace Fashi.Services.CartServ
{
    public interface ICartService
    {Task<CartVM> GetCartAsync(string userId);
        Task AddCartAsync(string userId, int productId);
        Task IncreaseQuantityAsync(string userId, int cartProductId);
        Task DecreaseQuantityAsync(string userId, int cartProductId);
        Task RemoveCartProductAsync(string userId, int cartProductId);

    }
}
