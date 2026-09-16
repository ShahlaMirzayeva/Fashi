using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BlogCategoryVm;
using Fashi.Dtos.BlogCategory;
using Fashi.Models;
using Fashi.Services.BlogCategoryServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IMapper _mapper;
        public BlogCategoryController(IBlogCategoryService blogCategoryService, IMapper mapper)
        {
            _blogCategoryService = blogCategoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var blogCategories = await _blogCategoryService.GetBlogCategoryAllAsync();
            return View(blogCategories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var blogCategory = _mapper.Map<BlogCategoryCreateDto>(model);
            await _blogCategoryService.AddBlogCategoryAsync(blogCategory);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _blogCategoryService.DeleteBlogCategoryAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var blogCategory = await _blogCategoryService.GetBlogCategoryByIdAsync(id);
            var model = _mapper.Map<UpdateBlogCategoryVm>(blogCategory);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogCategoryVm modelVm)
        {
            if (!ModelState.IsValid)
            {
                return View(modelVm);
            }

            var blogCategory = _mapper.Map<BlogCategoryUpdateDto>(modelVm);
            await _blogCategoryService.UpdateBlogCategoryAsync(blogCategory);
            return RedirectToAction("Index");
        }
    }
}
