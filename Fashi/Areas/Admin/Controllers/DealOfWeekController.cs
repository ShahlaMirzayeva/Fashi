using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DealOfWeekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
