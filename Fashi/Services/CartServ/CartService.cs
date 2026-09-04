using Fashi.Models;
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
        public async Task AddCartAsync(string userId, int productId)
        {var cart=await _cartRepository.GetByUserIdAsync(userId);
            if(cart == null)
            {
                cart = new Cart
                {
                    AppUserId = userId,
              
                };
                await _cartRepository.AddAsync(cart);
            }
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == productId);
            if (cartProduct! == null)
            {
                cartProduct.Quantity++;
            }
            else
            {
                cart.CartProducts.Add(new CartProduct
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }
            await _cartRepository.SaveAsync();
        }

        public async Task DecreaseQuantityAsync(string userId, int cartProductId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                throw new Exception("Cart not found.");
            }
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.Id == cartProductId);
            if (cartProduct == null)
            {
                throw new Exception("Cart product not found.");
            }
            if (cartProduct.Quantity > 1)
            {
                cartProduct.Quantity--;
            }
            else
            {
                cart.CartProducts.Remove(cartProduct);
            }

            await _cartRepository.UpdateAsync(cart);
            await _cartRepository.SaveAsync();
        }

        public async Task<CartVM> GetCartAsync(string userId)
        {var cart =await  _cartRepository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                return new CartVM();
             
            }
            var vm = new CartVM
            {
                CartProducts = cart.CartProducts.Select(cp => new CartVM
                {
                    Id = cp.Id,
                    ProductId = cp.ProductId,
                    Quantity = cp.Quantity,
                    ProductName = cp.Product.Name,
                    Price = cp.Product.Price,

                }).ToList()
            };
            return vm;
        }

        public async Task IncreaseQuantityAsync(string userId, int cartProductId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            if( cart == null)
            {
                throw new Exception("Cart product not found.");
            } 
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.Id == cartProductId);
            if(cartProduct == null)
            {
                throw new Exception("Cart product not found.");
            }   
            cartProduct.Quantity++;

            await _cartRepository.UpdateAsync(cart);
            await _cartRepository.SaveAsync();

      
        }

        public async Task RemoveCartProductAsync(string userId, int cartProductId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                throw new Exception("Cart product not found.");
            }
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.Id == cartProductId);
            if (cartProduct == null)
            {
                throw new Exception("Cart product not found.");
            }
            cart.CartProducts.Remove(cartProduct);
            await _cartRepository.SaveAsync();
        }
    }
}
