
using Fashi.Repositories;
using Fashi.Repositories.BenefitRepo;
using Fashi.Repositories.BlogCategoryRepo;
using Fashi.Repositories.CategoryBannerRepo;
using Fashi.Repositories.CategoryRepo;
using Fashi.Repositories.ColorRepo;
using Fashi.Repositories.DealOfWeekRepo;
using Fashi.Repositories.DiscoverRepo;
using Fashi.Repositories.GenderRepo;
using Fashi.Repositories.HomeBannerRepo;
using Fashi.Repositories.ProductRepo;
using Fashi.Repositories.SosialMediaRepo;
using Fashi.Services.AccountServ;
using Fashi.Services.BenefitServ;
using Fashi.Services.BlogCategoryServ;
using Fashi.Services.CategoryBannerServ;
using Fashi.Services.CategoryServ;
using Fashi.Services.ColorServ;
using Fashi.Services.DealOfWeekServ;
using Fashi.Services.DiscoverServ;
using Fashi.Services.FileServ;
using Fashi.Services.GenderServ;
using Fashi.Services.HomeBannerServ;
using Fashi.Services.HomeServ;
using Fashi.Services.ProductServ;
using Fashi.Services.SosialMediaServ;




namespace Fashi.Helpers.Extensions
{
    public static class ServiceExtention
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IGenderRepository, GenderRepository>();

            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IColorRepository, ColorRepository>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IHomeService, HomeService>();

            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<IBenefitRepository, BenefitRepository>();

            services.AddScoped<IHomeBannerService,HomeBannerService>();
            services.AddScoped<IHomeBannerRepository, HomeBannerRepository>();

            services.AddScoped<IDiscoverService,DiscoverService>();
            services.AddScoped<IDiscoverRepository, DiscoverRepository>();

            services.AddScoped<ISosialMediaService,SosialMediaService>();
            services.AddScoped<ISosialMediaRepository, SosialMediaRepository>();

            services.AddScoped<IDealOfWeekService, DealOfWeekService>();
            services.AddScoped<IDealOfWeekRepository, DealOfWeekRepository>();

            services.AddScoped<ICategoryBannerService, CategoryBannerService>();
            services.AddScoped<ICategoryBannerRepository, CategoryBannerRepository>();

            services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddScoped<IBlogCategoryService, BlogCategoryService>();





        }
    }
}
