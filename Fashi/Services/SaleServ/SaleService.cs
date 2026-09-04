using Fashi.Models;
using Fashi.Repositories.CartRepo;
using Fashi.Repositories.SaleRepo;

namespace Fashi.Services.SaleServ
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICartRepository _cartRepository;
        public SaleService(ISaleRepository saleRepository, ICartRepository cartRepository)
        {
            _saleRepository = saleRepository;
            _cartRepository = cartRepository;
        }
        public async Task CreateSaleAsync(string userId)
        {
           var cart=await _cartRepository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                throw new Exception("Cart not found.");
            }
            var sale = new Sale
            {
                AppUserId = userId,
                SaleTime = DateTime.UtcNow,
               Total=0,
               SaleProducts=new List<SaleProduct>()
            };
            foreach (var cartProduct in cart.CartProducts)
            {
                var product = cartProduct.Product;
                if(product.Count<cartProduct.Quantity)
                {
                    throw new Exception($"Not enough stock for product {product.Name}.");
                }
                var saleProduct = new SaleProduct
                {
                    ProductId = product.Id,
                    Quantity = cartProduct.Quantity,
                    Price = product.Price
                };
                sale.SaleProducts.Add(saleProduct);
                sale.Total += saleProduct.Price * saleProduct.Quantity;

                product.Count -= cartProduct.Quantity;

            }
            await _saleRepository.AddAsync(sale);
            await _cartRepository.DeleteAsync(cart.Id);
            await _saleRepository.SaveAsync();
        }
    }
}
