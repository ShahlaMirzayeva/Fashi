using AutoMapper;
using Fashi.Dtos.CategoryBanner;
using Fashi.Models;
using Fashi.Repositories.CategoryBannerRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.CategoryBannerServ
{
    public class CategoryBannerService : ICategoryBannerService
    {
        private readonly ICategoryBannerRepository _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public CategoryBannerService(ICategoryBannerRepository categoryRepository,IFileService fileService,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task AddCategoryBannerAsync(CategoryBannerCreateDto categoryBannerDto)
        {var newCategoryBanner = _mapper.Map<CategoryBanner>(categoryBannerDto);
            if(categoryBannerDto.Photo != null)
            {
                newCategoryBanner.Image = await _fileService.UploadFileAsync(categoryBannerDto.Photo, "category");
            }   

       
            await _categoryRepository.AddAsync(newCategoryBanner);
            await _categoryRepository.SaveAsync();

        }

        public async Task DeleteCategoryBannerAsync(int id)
        {
           var existingCategoryBanner = await _categoryRepository.GetByIdAsync(id);
            if (existingCategoryBanner == null) { throw new Exception("It is not found"); }

            _fileService.DeleteImage(existingCategoryBanner.Image);

            await _categoryRepository.DeleteAsync(id);
                await _categoryRepository.SaveAsync();
            
        }
        

        public async Task<IEnumerable<CategoryBannerDto>> GetAllCategoryBannerAsync()
        {var categoryBanners =await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryBannerDto>>(categoryBanners);
        }

        public async Task<CategoryBannerDto> GetByIdCategoryBannerAsync(int id)
        {
         var categoryBanner =await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryBannerDto>(categoryBanner);
        }

        public async Task UpdateCategoryBannerAsync(CategoryBannerUpdateDto categoryBannerDto)
        {
            var exisitingCategoryBanner = await _categoryRepository.GetByIdAsync(categoryBannerDto.Id);
            if (exisitingCategoryBanner == null)
            {
                throw new ArgumentException("CategoryBanner not found");
            }
            _mapper.Map(categoryBannerDto, exisitingCategoryBanner);
            if (categoryBannerDto.Photo != null)
            {
                _fileService.DeleteImage(exisitingCategoryBanner.Image);
                exisitingCategoryBanner.Image = await _fileService.UploadFileAsync(categoryBannerDto.Photo, "category");
            }
            await _categoryRepository.UpdateAsync(exisitingCategoryBanner);
            await _categoryRepository.SaveAsync();
        }
    }
}
