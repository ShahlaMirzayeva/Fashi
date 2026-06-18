using Fashi.Models;

namespace Fashi.Services.CategoryServ
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAync(int id);
    }
}
