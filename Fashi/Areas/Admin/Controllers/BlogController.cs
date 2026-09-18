using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BlogVm;
using Fashi.Areas.Admin.ViewModels.ProductVm;
using Fashi.Dtos.Blog;
using Fashi.Models;
using Fashi.Services.BlogCategoryServ;
using Fashi.Services.BlogServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IBlogCategoryService blogCategoryService, IMapper mapper)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var blog = await _blogService.GetBlogAllAsync();
            return View(blog);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.BlogCategories = await _blogCategoryService.GetBlogCategoryAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogVm blogVm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BlogCategories = await _blogCategoryService.GetBlogCategoryAllAsync();
                return View(blogVm);
            }
     
            var blogDto = _mapper.Map<BlogCreateDto>(blogVm);
            await _blogService.AddBlogAsync(blogDto, blogVm.Images);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteBlogAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            var updateBlogVm = _mapper.Map<UpdateBlogVm>(blog);
            ViewBag.BlogCategories = await _blogCategoryService.GetBlogCategoryAllAsync();
            if (blog.BlogImages!= null)
            {
                updateBlogVm.ExistingImages = blog.BlogImages.ToList();
            }
            return View(updateBlogVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogVm blogVm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BlogCategories = await _blogCategoryService.GetBlogCategoryAllAsync();
                return View(blogVm);
            }

            var blogDto = _mapper.Map<BlogUpdateDto>(blogVm);
            await _blogService.UpdateBlogAsync(blogDto);
            return RedirectToAction("Index");
        }
    }
}

