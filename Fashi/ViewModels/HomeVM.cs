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
        public IEnumerable<HomeBannerDto> HomeBanners { get; set; } = new List<HomeBannerDto>();    
        public IEnumerable<CategoryBannerDto> CategoryBanners { get; set; } = new List<CategoryBannerDto>();

        public IEnumerable<Discover> Discovers { get; set; } = new List<Discover>();
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public PagedResult<ProductDto> Products { get; set; }=new PagedResult<ProductDto>();
        public IEnumerable<DealOfWeekDto> DealOfWeeks { get; set; } = new List<DealOfWeekDto>();
        public IEnumerable<SosialMediaDto> SosialMedias { get; set; }= new List<SosialMediaDto>();
        public IEnumerable<BlogDto> Blogs { get; set; }= new List<BlogDto>();
        public IEnumerable<BenefitDto> Benefits { get; set; } = new List<BenefitDto>();
        public IEnumerable<Logo> Logos { get; set; } = new List<Logo>();
       
    }
}
