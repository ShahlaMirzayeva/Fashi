using Fashi.Dtos.Blog;
using Fashi.Models;

namespace Fashi.Services.BlogServ
{
    public interface IBlogService
    {Task<IEnumerable<BlogDto>> GetBlogAllAsync();
        Task<BlogDto> GetBlogByIdAsync(int id);
        Task AddBlogAsync(BlogCreateDto blogCreateDto,List<IFormFile>blogImages);
        Task UpdateBlogAsync(BlogUpdateDto blogUpdateDto);
        Task DeleteBlogAsync(int id);
    }
}
