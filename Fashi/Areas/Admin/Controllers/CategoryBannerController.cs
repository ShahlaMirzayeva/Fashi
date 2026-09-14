using AutoMapper;
using Fashi.Areas.Admin.ViewModels.CategoryBannerVm;
using Fashi.Dtos.CategoryBanner;
using Fashi.Models;
using Fashi.Services.CategoryBannerServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryBannerController : Controller
    {
        private readonly ICategoryBannerService _categoryBannerService;
        private readonly IMapper _mapper;
        public CategoryBannerController(ICategoryBannerService categoryBanner, IMapper mapper)
        {
            _categoryBannerService = categoryBanner;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {var categoryBanners = await _categoryBannerService.GetAllCategoryBannerAsync();
            return View(categoryBanners);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryBannerVm categoryBannerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryBannerVm);
            }
            var categoryBanner = _mapper.Map<CategoryBannerCreateDto>(categoryBannerVm);
            await _categoryBannerService.AddCategoryBannerAsync(categoryBanner);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryBannerService.DeleteCategoryBannerAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var categoryBanner = await _categoryBannerService.GetByIdCategoryBannerAsync(id);
            var categoryBannerVm = _mapper.Map<UpdateCategoryBannerVm>(categoryBanner);
            return View(categoryBannerVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryBannerVm categoryBannerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryBannerVm);
            }
            var categoryBanner = _mapper.Map<CategoryBannerUpdateDto>(categoryBannerVm);
            await _categoryBannerService.UpdateCategoryBannerAsync(categoryBanner);
            return RedirectToAction(nameof(Index));
        }
    }
}
