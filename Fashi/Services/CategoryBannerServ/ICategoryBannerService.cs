using Fashi.Models;

namespace Fashi.Services.CategoryBannerServ
{
    public interface ICategoryBannerService
    {Task<IEnumerable<CategoryBanner>> GetAllCategoryBannerAsync();
        Task<CategoryBanner> GetByIdCategoryBannerAsync(int id);
        Task AddCategoryBannerAsync(CategoryBanner categoryBanner);
        Task DeleteCategoryBannerAsync(int id);
        Task UpdateCategoryBannerAsync(CategoryBanner categoryBanner);
    }
}
