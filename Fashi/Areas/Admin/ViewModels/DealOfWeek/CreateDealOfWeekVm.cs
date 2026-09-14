namespace Fashi.Areas.Admin.ViewModels.DealOfWeek
{
    public class CreateDealOfWeekVm
    {
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DealofTime { get; set; }
        public double Price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
