namespace Fashi.Dtos.DealOfWeek
{
    public class DealOfWeekCreateDto
    {
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DealofTime { get; set; }
        public double Price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
