namespace Fashi.Areas.Admin.ViewModels.HomeBannerVm
{
    public class CreateHomeBannerVm
    {
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }

        public IFormFile Photo { get; set; }

    }
}
