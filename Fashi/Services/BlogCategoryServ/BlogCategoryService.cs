using Fashi.Models;
using Fashi.Repositories.BlogCategoryRepo;

namespace Fashi.Services.BlogCategoryServ
{
    public class BlogCategoryService : IBlogCategoryService
    {private readonly IBlogCategoryRepository _blogCategoryRepository;
        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }
        public async Task AddBlogCategoryAsync(BlogCategory blogCategory)
        {var newBlogCategory = new BlogCategory
        {
            Name = blogCategory.Name
           
        };
           await _blogCategoryRepository.AddAsync(newBlogCategory);
            await _blogCategoryRepository.SaveAsync();
        }

        public async Task DeleteBlogCategoryAsync(int id)
        {
            
                await _blogCategoryRepository.DeleteAsync(id);
                await _blogCategoryRepository.SaveAsync();
            
        }

        public async Task<IEnumerable<BlogCategory>> GetBlogCategoryAllAsync()
        {var blogCategories =await _blogCategoryRepository.GetAllAsync();
            return blogCategories;
        }

        public async Task<BlogCategory> GetBlogCategoryByIdAsync(int id)
        {
            var blogCategory =await _blogCategoryRepository.GetByIdAsync(id);
            return blogCategory;
        }

        public async Task UpdateBlogCategoryAsync(BlogCategory blogCategory)
        {var existingBlogCategory = await _blogCategoryRepository.GetByIdAsync(blogCategory.Id);
            if (existingBlogCategory != null)
            {
                existingBlogCategory.Name = blogCategory.Name;
                await _blogCategoryRepository.UpdateAsync(existingBlogCategory);
                await _blogCategoryRepository.SaveAsync();
            }
            
        }
    }
}
