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

     

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            await _categoryRepository.SaveAsync();
        }

     

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllAsync(x=>x.Gender);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
           return await _categoryRepository.GetByIdAsync(id);
        }

     

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveAsync();
        }
    }
}
