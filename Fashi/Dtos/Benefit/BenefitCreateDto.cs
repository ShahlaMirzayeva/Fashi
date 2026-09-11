namespace Fashi.Dtos.Benefit
{
    public class BenefitCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile IconUrl { get; set; }
    }
}
