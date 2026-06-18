using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.ProductRepo
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
