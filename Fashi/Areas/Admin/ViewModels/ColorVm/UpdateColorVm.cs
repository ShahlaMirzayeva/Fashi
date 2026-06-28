using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.ViewModels.ColorVm
{
    public class UpdateColorVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Color name is required.")]
        public string  ColorName { get; set; }
    }
}
