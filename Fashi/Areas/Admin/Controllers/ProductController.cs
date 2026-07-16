using AutoMapper;
using Fashi.Areas.Admin.ViewModels.ProductVm;
using Fashi.Dtos.Product;
using Fashi.Models;
using Fashi.Services.CategoryServ;
using Fashi.Services.ColorServ;
using Fashi.Services.ProductServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IColorService colorService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _colorService = colorService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Colors = await _colorService.GetAllColorAsync();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateProductVm createProductVm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
                ViewBag.Colors = await _colorService.GetAllColorAsync();
                return View(createProductVm);
            }

            if (createProductVm == null && createProductVm.Images.Count > 6)
            {
                ModelState.AddModelError("Images", "You can upload a maximum of 6 images.");
                ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
                return View(createProductVm);
            }

            //ProductCreateDto product = new ProductCreateDto
            //{
            //    Name = createProductVm.Name,
            //    Count = createProductVm.Count,
            //    Price = createProductVm.Price,
            //    Discount = createProductVm.Discount,
            //    Size = createProductVm.Size,
            //    CategoryId = createProductVm.CategoryId,

            //};
            var product= _mapper.Map<ProductCreateDto>(createProductVm);
            await _productService.AddProductAsync(product, createProductVm.Images, createProductVm.ColorIds);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            //UpdateProductVm updateProductVm = new UpdateProductVm
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Count = product.Count,
            //    Price = product.Price,
            //    Discount = product.Discount,
            //    Size = product.Size,
            //    CategoryId = product.CategoryId,
            //    ColorIds = product.ColorProducts.Select(cp => cp.ColorId).ToList(),
            //};
            var updateProductVm = _mapper.Map<UpdateProductVm>(product);
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Colors = await _colorService.GetAllColorAsync();
            if (product.ProductImages != null)
            {
                updateProductVm.ExistingImages = product.ProductImages.ToList();
            }
            return View(updateProductVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVm updateProductVm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
                ViewBag.Colors = await _colorService.GetAllColorAsync();
                return View(updateProductVm);
            }
            //ProductUpdateDto productUpdateDto = new ProductUpdateDto
            //{
            //    Id = updateProductVm.Id,
            //    Name = updateProductVm.Name,
            //    Count = updateProductVm.Count,
            //    Price = updateProductVm.Price,
            //    Discount = updateProductVm.Discount,
            //    Size = updateProductVm.Size,
            //    CategoryId = updateProductVm.CategoryId,
            //};
           var product= _mapper.Map<ProductUpdateDto>(updateProductVm);
            await _productService.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
