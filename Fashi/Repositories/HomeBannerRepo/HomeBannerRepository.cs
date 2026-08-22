using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.HomeBannerRepo
{
    public class HomeBannerRepository:Repository<HomeBanner>,IHomeBannerRepository
    {
        public HomeBannerRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
