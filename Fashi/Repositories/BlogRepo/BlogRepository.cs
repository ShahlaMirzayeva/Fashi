using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.BlogRepo
{
    public class BlogRepository:Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
