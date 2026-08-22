using Fashi.Models;

namespace Fashi.Services.BlogServ
{
    public interface IBlogService
    {Task<IEnumerable<Blog>> GetBlogAllAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task AddBlogAsync(Blog blog);
        Task UpdateBlogAsync(Blog blog);
        Task DeleteBlogAsync(int id);
    }
}
