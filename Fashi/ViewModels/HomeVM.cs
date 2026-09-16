using Fashi.Dtos.Benefit;
using Fashi.Dtos.Blog;
using Fashi.Dtos.Category;
using Fashi.Dtos.CategoryBanner;
using Fashi.Dtos.DealOfWeek;
using Fashi.Dtos.HomeBanner;
using Fashi.Dtos.Product;
using Fashi.Dtos.SosialMedia;
using Fashi.Models;
using Fashi.Models.Common;

namespace Fashi.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<HomeBannerDto> HomeBanners { get; set; }
        public IEnumerable<CategoryBannerDto> CategoryBanners { get; set; }

        public IEnumerable<Discover> Discovers { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public PagedResult<ProductDto> Products { get; set; }
        public IEnumerable<DealOfWeekDto> DealOfWeeks { get; set; }
        public IEnumerable<SosialMediaDto> SosialMedias { get; set; }
        public IEnumerable<BlogDto> Blogs { get; set; }
        public IEnumerable<BenefitDto> Benefits { get; set; }
        public IEnumerable<Logo> Logos { get; set; }
       
    }
}
