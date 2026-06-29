using Fashi.Areas.Admin.ViewModels.ProductVm;
using Fashi.Models;
using Fashi.Services.CategoryServ;
using Fashi.Services.ProductServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var products =await _productService.GetAllProductAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult>Create(CreateProductVm createProductVm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
                return View(createProductVm);
            }

            if (createProductVm == null && createProductVm.Images.Count > 6) { 
            ModelState.AddModelError("Images", "You can upload a maximum of 6 images.");
                ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
                return View(createProductVm);
            }

            Product product = new Product
            {
                Name = createProductVm.Name,
                Count = createProductVm.Count,
                Price = createProductVm.Price,
                Discount = createProductVm.Discount,
                Size = createProductVm.Size,
                CategoryId = createProductVm.CategoryId,
                LikeIcon = createProductVm.LikeIcon
            };
            await _productService.AddProductAsync(product, createProductVm.Images);
            return RedirectToAction(nameof(Index));
        }
    }
}
