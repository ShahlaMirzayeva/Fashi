
using Fashi.Areas.Admin.ViewModels.AccountVm;
using Fashi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Fashi.Services.AccountServ
{
    public class AccountService : IAccountService
    {private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> LoginAsync(LoginVm model)
        {var user =await _userManager.FindByEmailAsync(model.Email);
            if (user == null) { return SignInResult.Failed; }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> AdminRegisterAsync(AdminRegisterVm model)
        {
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
    
            };

             var result =await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
               }

                return result;
        }
    }
}
