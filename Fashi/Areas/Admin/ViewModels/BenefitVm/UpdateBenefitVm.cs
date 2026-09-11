namespace Fashi.Areas.Admin.ViewModels.BenefitVm
{
    public class UpdateBenefitVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? IconUrl { get; set; }
    }
}
