using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.ViewModels.GenderVm
{
    public class UpdateGenderVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
