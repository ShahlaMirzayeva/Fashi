using Fashi.Dtos.Product;
using Fashi.Models;

namespace Fashi.Services.ProductServ
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductCreateDto product,List<IFormFile>images,List<int>colorIds);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(ProductUpdateDto productDto);
    }
}
