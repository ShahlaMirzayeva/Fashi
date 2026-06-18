using Fashi.Models;

namespace Fashi.Services.ProductServ
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}
