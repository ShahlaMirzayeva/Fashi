using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fashi.ViewModels;
using Fashi.Data;
using Fashi.Services.CategoryServ;
using Fashi.Services.ProductServ;
using Microsoft.EntityFrameworkCore;


namespace Fashi.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
  

    public HomeController(AppDbContext context,ICategoryService categoryService,IProductService productService)
    {
        _context = context;
        _categoryService = categoryService;
        _productService = productService;
        
    }
    public async Task<IActionResult> Index(int page=1,int pageSize=8,string?search=null,int? categoryId=null,string?sort=null)
    {
        var categories = await _categoryService.GetAllCategoryAsync();
        var products = await _productService.GetAllProductAsync(page,pageSize,search,categoryId,sort);

        HomeVM homeVM = new HomeVM
        {
            HomeBanners = _context.HomeBanners,
            CategoryBanners=_context.CategoryBanners,
            Discovers=_context.Discovers,
            Categories = categories,
            Products = products,
            DealOfWeeks =_context.DealOfWeeks,
            SosialMedias=_context.SosialMedias,
            Blogs=_context.Blogs.Include(b=>b.BlogImages),
            Benefits=_context.Benefits,
            Logos=_context.Logos
           
        };
        return View(homeVM);
    }
   

}
