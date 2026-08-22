using Fashi.Dtos.Category;
using Fashi.Dtos.Product;
using Fashi.Models;
using Fashi.Models.Common;

namespace Fashi.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<HomeBanner> HomeBanners { get; set; }
        public IEnumerable<CategoryBanner> CategoryBanners { get; set; }

        public IEnumerable<Discover> Discovers { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public PagedResult<ProductDto> Products { get; set; }
        public IEnumerable<DealOfWeek> DealOfWeeks { get; set; }
        public IEnumerable<SosialMedia> SosialMedias { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Benefit> Benefits { get; set; }
        public IEnumerable<Logo> Logos { get; set; }
       
    }
}
