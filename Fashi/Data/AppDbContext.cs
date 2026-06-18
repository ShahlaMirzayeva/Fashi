using Fashi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Fashi.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<HomeBanner> HomeBanners { get; set; }
        public DbSet<CategoryBanner> CategoryBanners { get; set; }

        public DbSet<Discover> Discovers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Color> Colors { get; set; }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<DealOfWeek> DealOfWeeks { get; set; }
        public DbSet<SosialMedia> SosialMedias { get; set; }
        public DbSet<ColorProduct> ColorProducts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<BlogCategory>BlogCategories{ get; set; }
    }
}
