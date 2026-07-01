using Fashi.Models;

namespace Fashi.Repositories.ProductRepo
{
    public interface IProductRepository:IRepository<Product>
    {Task<IEnumerable<Product>> GetAllProductWithDetailAsync();
        Task<Product > GetByIdProductWithDetailAsync(int id);
    }
}
