using AutoMapper;
using Fashi.Dtos.Category;
using Fashi.Models;
using Fashi.Repositories.CategoryRepo;

namespace Fashi.Services.CategoryServ
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

     

        public async Task AddCategoryAsync(CategoryCreateDto categoryDto)
        {var category= _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            await _categoryRepository.SaveAsync();
        }

     

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var category= await _categoryRepository.GetAllAsync(x=>x.Gender);
            return _mapper.Map<IEnumerable<CategoryDto>>(category);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
          var catgory= await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(catgory);
        }

     

        public async Task UpdateCategoryAsync(CategoryUpdateDto categoryDto)
        {
           
            var category = await _categoryRepository.GetByIdAsync(categoryDto.Id);
            if(category == null) throw new Exception("Category not found");
            _mapper.Map(categoryDto, category);
            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveAsync();
        }
    }
}
