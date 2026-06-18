using Fashi.Models;

namespace Fashi.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<HomeBanner> HomeBanners { get; set; }
        public IEnumerable<CategoryBanner> CategoryBanners { get; set; }

        public IEnumerable<Discover> Discovers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<DealOfWeek> DealOfWeeks { get; set; }
        public IEnumerable<SosialMedia> SosialMedias { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Benefit> Benefits { get; set; }
        public IEnumerable<Logo> Logos { get; set; }
       
    }
}
