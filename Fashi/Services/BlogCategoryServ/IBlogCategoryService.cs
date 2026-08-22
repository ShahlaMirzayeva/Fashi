using Fashi.Models;

namespace Fashi.Services.BlogCategoryServ
{
    public interface IBlogCategoryService
    {Task<IEnumerable<BlogCategory>> GetBlogCategoryAllAsync();
        Task<BlogCategory> GetBlogCategoryByIdAsync(int id);
        Task AddBlogCategoryAsync(BlogCategory blogCategory);
        Task UpdateBlogCategoryAsync(BlogCategory blogCategory);
        Task DeleteBlogCategoryAsync(int id);
    }
}
