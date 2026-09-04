using Fashi.Data;
using Fashi.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashi.Repositories.CartRepo
{
    public class CartRepository: Repository<Cart>,ICartRepository
    {
        public CartRepository(AppDbContext context):base(context)
        {
            
        }
        public async Task<Cart?> GetByUserIdAsync(string userId)
        {
            return await _context.Cart
                .Include(x => x.CartProducts)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.AppUserId == userId);
        }
    }
}
