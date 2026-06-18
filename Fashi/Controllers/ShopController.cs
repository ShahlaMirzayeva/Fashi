using Microsoft.AspNetCore.Mvc;

namespace Fashi.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
