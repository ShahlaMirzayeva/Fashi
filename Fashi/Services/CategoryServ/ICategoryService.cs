using Fashi.Dtos.Category;
using Fashi.Models;

namespace Fashi.Services.CategoryServ
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);

        Task AddCategoryAsync(CategoryCreateDto categoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(CategoryUpdateDto categoryDto);
    }
}
