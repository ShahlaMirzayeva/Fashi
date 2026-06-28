using Fashi.Repositories;
using Fashi.Repositories.CategoryRepo;
using Fashi.Repositories.ColorRepo;
using Fashi.Repositories.GenderRepo;
using Fashi.Repositories.ProductRepo;
using Fashi.Services.CategoryServ;
using Fashi.Services.ColorServ;
using Fashi.Services.GenderServ;
using Fashi.Services.ProductServ;



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






        }
    }
}
