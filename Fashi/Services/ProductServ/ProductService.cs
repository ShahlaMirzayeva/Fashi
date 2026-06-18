using Fashi.Models;
using Fashi.Repositories.ProductRepo;

namespace Fashi.Services.ProductServ
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository )
        {
            _productRepository = productRepository;
            
        }
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllAsync(p => p.ProductImages,p=>p.Category);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
