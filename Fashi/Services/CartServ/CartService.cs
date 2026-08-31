using Fashi.Repositories.CartRepo;
using Fashi.ViewModels.CartVm;

namespace Fashi.Services.CartServ
{
    public class CartService : ICartService
    {private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public Task AddCartAsync(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task DecreaseQuantityAsync(string userId, int cartProductId)
        {
            throw new NotImplementedException();
        }

        public Task<CartVM> GetCartAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task IncreaseQuantityAsync(string userId, int cartProductId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCartProductAsync(string userId, int cartProductId)
        {
            throw new NotImplementedException();
        }
    }
}
