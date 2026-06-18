using Fashi.Models;
using Fashi.Repositories.CategoryRepo;

namespace Fashi.Services.CategoryServ
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAync(int id)
        {
           return await _categoryRepository.GetByIdAsync(id);
        }
    }
}
