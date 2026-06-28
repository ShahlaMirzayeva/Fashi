using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.ViewModels.ColorVm
{
    public class CreateColorVm
    {
        [Required (ErrorMessage = "Color name is required.")]
        public string ColorName { get; set; }
    }
}
