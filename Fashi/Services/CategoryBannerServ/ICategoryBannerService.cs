using Fashi.Dtos.CategoryBanner;
using Fashi.Models;

namespace Fashi.Services.CategoryBannerServ
{
    public interface ICategoryBannerService
    {Task<IEnumerable<CategoryBannerDto>> GetAllCategoryBannerAsync();
        Task<CategoryBannerDto> GetByIdCategoryBannerAsync(int id);
        Task AddCategoryBannerAsync(CategoryBannerCreateDto categoryBanner);
        Task DeleteCategoryBannerAsync(int id);
        Task UpdateCategoryBannerAsync(CategoryBannerUpdateDto categoryBanner);
    }
}
