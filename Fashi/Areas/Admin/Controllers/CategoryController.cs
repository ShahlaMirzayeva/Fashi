using Fashi.Areas.Admin.ViewModels.CategoryVm;
using Fashi.Models;
using Fashi.Repositories.CategoryRepo;
using Fashi.Services.CategoryServ;
using Fashi.Services.GenderServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IGenderService _genderService;
        public CategoryController(ICategoryService categoryService, IGenderService genderService)
        {
            _categoryService = categoryService;
            _genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Genders = await _genderService.GetAllGenderAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVm createCategoryVm)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Genders = await _genderService.GetAllGenderAsync();
                return View(createCategoryVm);

            }
            Category category = new Category
            {
                Name = createCategoryVm.Name,
                GenderId = createCategoryVm.GenderId
            };
            await _categoryService.AddCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            UpdateCategoryVm updateCategoryVm = new UpdateCategoryVm
            {
                Name = category.Name,
                GenderId = category.GenderId,
                Id= category.Id
            };
            ViewBag.Genders = await _genderService.GetAllGenderAsync();
            return View(updateCategoryVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVm updateCategoryVm) {
          
            if (!ModelState.IsValid)
            {
                ViewBag.Genders = await _genderService.GetAllGenderAsync();
                return View(updateCategoryVm);
            }
            var category = await _categoryService.GetCategoryByIdAsync(updateCategoryVm.Id);
            if(category == null) return NotFound();
            category.Name = updateCategoryVm.Name;
              category.GenderId = updateCategoryVm.GenderId;
            await _categoryService.UpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));

        }
    }
}
