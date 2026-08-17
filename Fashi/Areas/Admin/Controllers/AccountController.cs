using Fashi.Areas.Admin.ViewModels.AccountVm;
using Fashi.Services.AccountServ;
using Fashi.ViewModels.AccountVm;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        public AccountController(IAccountService accountService)
        {
            _account= accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AdminRegisterVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _account.AdminRegisterAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _account.LoginAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
        public IActionResult Logout()
        {
            _account.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
