using Fashi.Areas.Admin.ViewModels.AccountVm;
using Fashi.ViewModels.AccountVm;
using Microsoft.AspNetCore.Identity;

namespace Fashi.Services.AccountServ
{
    public interface IAccountService
    {
        Task<IdentityResult> AdminRegisterAsync(AdminRegisterVm model);
        Task<IdentityResult> RegisterAsync(RegisterVm model);
      
        Task<SignInResult> LoginAsync(LoginVm model);
        Task LogoutAsync();
    }
}
