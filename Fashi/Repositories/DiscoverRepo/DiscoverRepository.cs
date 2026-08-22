using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.DiscoverRepo
{
    public class DiscoverRepository:Repository<Discover>, IDiscoverRepository
    {
        public DiscoverRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
