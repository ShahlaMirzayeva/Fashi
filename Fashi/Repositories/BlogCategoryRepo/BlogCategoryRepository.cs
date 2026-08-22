using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.BlogCategoryRepo
{
    public class BlogCategoryRepository: Repository<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
