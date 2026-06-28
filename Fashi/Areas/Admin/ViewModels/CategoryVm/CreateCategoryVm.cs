using Fashi.Models;
using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.ViewModels.CategoryVm
{
    public class CreateCategoryVm
    {
        [Required(ErrorMessage = "Name is required")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public int? GenderId { get; set; }
    }
}
