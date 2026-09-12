using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Areas.Admin.ViewModels.CategoryBannerVm
{
    public class CreateCategoryBannerVm
    {
        public string Name { get; set; }
       
        public IFormFile Photo { get; set; }
    }
}
