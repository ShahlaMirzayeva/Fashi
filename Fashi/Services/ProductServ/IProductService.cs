using Fashi.Models;

namespace Fashi.Services.ProductServ
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product,List<IFormFile>images,List<int>colorIds);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Product product,List<IFormFile>images,List<int>deleteImageIds);
    }
}
