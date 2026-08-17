using Fashi.Services.AccountServ;
using Fashi.ViewModels.AccountVm;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        public AccountController(IAccountService account)
        {
            _account = account;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var result = await _account.RegisterAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
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
