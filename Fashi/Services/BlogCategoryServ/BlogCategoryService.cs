using AutoMapper;
using Fashi.Dtos.BlogCategory;
using Fashi.Models;
using Fashi.Repositories.BlogCategoryRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.BlogCategoryServ
{
    public class BlogCategoryService : IBlogCategoryService
    {private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IMapper _mapper;
      
        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository, IMapper mapper)
        {
            _blogCategoryRepository = blogCategoryRepository;
            _mapper = mapper;
         
        }
        public async Task AddBlogCategoryAsync(BlogCategoryCreateDto blogCategoryDto)
        {var newBlogCategory = _mapper.Map<BlogCategory>(blogCategoryDto);
        
            await _blogCategoryRepository.AddAsync(newBlogCategory);
            await _blogCategoryRepository.SaveAsync();
        }

        public async Task DeleteBlogCategoryAsync(int id)
        {
            
                await _blogCategoryRepository.DeleteAsync(id);
                await _blogCategoryRepository.SaveAsync();
            
        }

        public async Task<IEnumerable<BlogCategoryDto>> GetBlogCategoryAllAsync()
        {var blogCategories =await _blogCategoryRepository.GetAllAsync();
            return  _mapper.Map<IEnumerable<BlogCategoryDto>>(blogCategories);
        }

        public async Task<BlogCategoryDto> GetBlogCategoryByIdAsync(int id)
        {
            var blogCategory =await _blogCategoryRepository.GetByIdAsync(id);
            return _mapper.Map<BlogCategoryDto>(blogCategory);
        }

        public async Task UpdateBlogCategoryAsync(BlogCategoryUpdateDto blogCategoryDto)
        {var existingBlogCategory = await _blogCategoryRepository.GetByIdAsync(blogCategoryDto.Id);
            if (existingBlogCategory != null)
            {
              _mapper.Map(blogCategoryDto, existingBlogCategory);
                await _blogCategoryRepository.UpdateAsync(existingBlogCategory);
                await _blogCategoryRepository.SaveAsync();
            }
            
        }
    }
}
