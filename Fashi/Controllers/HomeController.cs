using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fashi.ViewModels;
using Fashi.Data;
using Fashi.Services.CategoryServ;
using Fashi.Services.ProductServ;
using Microsoft.EntityFrameworkCore;
using Fashi.Services.HomeServ;


namespace Fashi.Controllers;

public class HomeController : Controller
{
    private readonly IHomeService _homeService;
  

    public HomeController(IHomeService homeService)
    {

        _homeService = homeService;
    }
    public async Task<IActionResult> Index(int page=1,int pageSize=8,string?search=null,int? categoryId=null,string?sort=null)
    {
       

 
        return View(await _homeService.GetHomeDataAsync(page, pageSize, search, categoryId, sort));


    }
   

}
