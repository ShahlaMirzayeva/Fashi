namespace Fashi.Areas.Admin.ViewModels.HomeBannerVm
{
    public class UpdateHomeBannerVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }
       
        public IFormFile? Photo { get; set; }
    }
}
