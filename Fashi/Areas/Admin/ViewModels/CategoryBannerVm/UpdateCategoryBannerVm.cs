namespace Fashi.Areas.Admin.ViewModels.CategoryBannerVm
{
    public class UpdateCategoryBannerVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
