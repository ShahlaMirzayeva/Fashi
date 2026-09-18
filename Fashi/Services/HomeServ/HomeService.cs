using Fashi.Services.BenefitServ;
using Fashi.Services.BlogServ;
using Fashi.Services.CategoryBannerServ;
using Fashi.Services.CategoryServ;
using Fashi.Services.DealOfWeekServ;
using Fashi.Services.HomeBannerServ;
using Fashi.Services.ProductServ;
using Fashi.Services.SosialMediaServ;
using Fashi.ViewModels;

namespace Fashi.Services.HomeServ
{
    public class HomeService : IHomeService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBenefitService _benefitService;
        private readonly IHomeBannerService _homeBannerService;
        private readonly ICategoryBannerService _categoryBannerService;
        private readonly IDealOfWeekService _dealOfWeekService;
        private readonly ISosialMediaService _sosialMediaService;
        private readonly IBlogService _blogService;
   

        public HomeService(IProductService productService, ICategoryService categoryService, IBenefitService benefitService, 
            IHomeBannerService homeBannerService, 
            ICategoryBannerService categoryBannerService, IDealOfWeekService dealOfWeekService,
            ISosialMediaService sosialMediaService,
            IBlogService blogService
            )
        {
            _productService = productService;
            _categoryService = categoryService;
            _benefitService = benefitService;
            _homeBannerService = homeBannerService;
            _categoryBannerService = categoryBannerService;
            _dealOfWeekService = dealOfWeekService;
            _sosialMediaService = sosialMediaService;
            _blogService = blogService;
        }
        public async Task<HomeVM> GetHomeDataAsync(int page,
        int pageSize,
        string? search,
        int? categoryId,
        string? sort)
        {
            var products = await _productService.GetAllProductAsync(page, pageSize,search, categoryId,sort);
            var categories = await _categoryService.GetAllCategoryAsync();
            var benefits = await _benefitService.GetAllBenefitsAsync();
            var homeBanners = await _homeBannerService.GetAllHomeBannerAsync();
            var categoryBanners = await _categoryBannerService.GetAllCategoryBannerAsync();
            var dealOfWeeks = await _dealOfWeekService.GetAllDealOfWeekAsync();
            var sosialMedias = await _sosialMediaService.GetAllSosialMediaAsync();
            var blogs = await _blogService.GetBlogAllAsync();
            HomeVM homeVM = new HomeVM
            {
                Products =products,
                Categories =categories,
                Benefits =benefits,
                HomeBanners =homeBanners,
                CategoryBanners = categoryBanners,
                DealOfWeeks = dealOfWeeks,
                SosialMedias = sosialMedias,
                Blogs = blogs,
            };
       
            return homeVM;
        }
    }
}
