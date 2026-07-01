using Fashi.Areas.Admin.ViewModels.ProductVm;
using Fashi.Models;
using Fashi.Services.CategoryServ;
using Fashi.Services.ColorServ;
using Fashi.Services.ProductServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;

        public ProductController(IProductService productService,ICategoryService categoryService,IColorService colorService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _colorService = colorService;
        }
        public async Task<IActionResult> Index()
        {
            var products =await _productService.GetAllProductAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Colors = await _colorService.GetAllColorAsync();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult>Create(CreateProductVm createProductVm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
                ViewBag.Colors=await _colorService.GetAllColorAsync();
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
                LikeCount = 0
            };
            await _productService.AddProductAsync(product, createProductVm.Images,createProductVm.ColorIds);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Detail(int id)
        {var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
