using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.ViewModels.GenderVm
{
    public class CreateGenderVm
    {
        [Required (ErrorMessage ="Can't be empty")]
        public string Name { get; set; }
    }
}
