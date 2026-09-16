using Fashi.Dtos.BlogCategory;
using Fashi.Models;

namespace Fashi.Services.BlogCategoryServ
{
    public interface IBlogCategoryService
    {Task<IEnumerable<BlogCategoryDto>> GetBlogCategoryAllAsync();
        Task<BlogCategoryDto> GetBlogCategoryByIdAsync(int id);
        Task AddBlogCategoryAsync(BlogCategoryCreateDto blogCategory);
        Task UpdateBlogCategoryAsync(BlogCategoryUpdateDto blogCategory);
        Task DeleteBlogCategoryAsync(int id);
    }
}
