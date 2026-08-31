using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.CartRepo
{
    public class CartRepository: Repository<Cart>,ICartRepository
    {
        public CartRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
