using Fashi.Data;
using Fashi.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashi.Repositories.ProductRepo
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Product>> GetAllProductWithDetailAsync()
        {
       return await _context.Products.Include(p=>p.Category).
                Include(p=>p.ProductImages).
                Include(p=>p.ColorProducts).
                ThenInclude(pc=>pc.Color).ToListAsync(); 
        }
        public async Task<Product> GetByIdProductWithDetailAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).
                     Include(p => p.ProductImages).
                     Include(p => p.ColorProducts).
                     ThenInclude(pc => pc.Color).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
