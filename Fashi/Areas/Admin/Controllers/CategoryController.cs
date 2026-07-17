using AutoMapper;
using Fashi.Areas.Admin.ViewModels.CategoryVm;
using Fashi.Dtos.Category;
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
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IGenderService genderService, IMapper mapper)
        {
            _categoryService = categoryService;
            _genderService = genderService;
            _mapper = mapper;
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
            //CategoryCreateDto category = new CategoryCreateDto
            //{
            //    Name = createCategoryVm.Name,
            //    GenderId = createCategoryVm.GenderId
            //};
            var category= _mapper.Map<CategoryCreateDto>(createCategoryVm);
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

            //UpdateCategoryVm updateCategoryVm = new UpdateCategoryVm
            //{
            //    Name = category.Name,
            //    GenderId = category.GenderId,
            //    Id= category.Id
            //};
            var updateCategoryVm = _mapper.Map<UpdateCategoryVm>(category);
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
          
            //var categoryDto = new CategoryUpdateDto
            //{
            //    Id= updateCategoryVm.Id,
            //    Name = updateCategoryVm.Name,
            //    GenderId = updateCategoryVm.GenderId
            //};
           var categoryDto = _mapper.Map<CategoryUpdateDto>(updateCategoryVm);
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return RedirectToAction(nameof(Index));

        }
    }
}
