using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.CategoryRepo
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
