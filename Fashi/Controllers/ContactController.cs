using Microsoft.AspNetCore.Mvc;

namespace Fashi.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
