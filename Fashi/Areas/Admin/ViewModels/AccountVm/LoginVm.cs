using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.ViewModels.AccountVm
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
