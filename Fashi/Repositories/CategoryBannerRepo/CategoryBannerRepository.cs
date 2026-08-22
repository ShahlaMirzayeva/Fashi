using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.CategoryBannerRepo
{
    public class CategoryBannerRepository: Repository<CategoryBanner>, ICategoryBannerRepository
    {
        public CategoryBannerRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
