using Fashi.Models;
using Fashi.Repositories.CategoryBannerRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.CategoryBannerServ
{
    public class CategoryBannerService : ICategoryBannerService
    {
        private readonly ICategoryBannerRepository _categoryRepository;
        private readonly IFileService _fileService;
        public CategoryBannerService(ICategoryBannerRepository categoryRepository,IFileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }
        public async Task AddCategoryBannerAsync(CategoryBanner categoryBanner)
        {string fileName = await _fileService.UploadFileAsync(categoryBanner.Photo,"category");

            var newCategoryBanner=new CategoryBanner
        {
            Name = categoryBanner.Name,
            Image = fileName,
           
        };
            await _categoryRepository.AddAsync(newCategoryBanner);
            await _categoryRepository.SaveAsync();

        }

        public async Task DeleteCategoryBannerAsync(int id)
        {
           var existingCategoryBanner = await _categoryRepository.GetByIdAsync(id);
            if (existingCategoryBanner != null) { throw new Exception("It is not found"); }

            _fileService.DeleteImage(existingCategoryBanner.Image);

            await _categoryRepository.DeleteAsync(id);
                await _categoryRepository.SaveAsync();
            
        }
        

        public Task<IEnumerable<CategoryBanner>> GetAllCategoryBannerAsync()
        {var categoryBanners = _categoryRepository.GetAllAsync();
            return categoryBanners;
        }

        public Task<CategoryBanner> GetByIdCategoryBannerAsync(int id)
        {
         var categoryBanner = _categoryRepository.GetByIdAsync(id);
            return categoryBanner;
        }

        public async Task UpdateCategoryBannerAsync(CategoryBanner categoryBanner)
        {
            var exisitingCategoryBanner = await _categoryRepository.GetByIdAsync(categoryBanner.Id);
            exisitingCategoryBanner.Name = categoryBanner.Name;
            if (categoryBanner.Photo != null)
            {
                _fileService.DeleteImage(exisitingCategoryBanner.Image);
                exisitingCategoryBanner.Image = await _fileService.UploadFileAsync(categoryBanner.Photo, "category");
            }
        }
    }
}
