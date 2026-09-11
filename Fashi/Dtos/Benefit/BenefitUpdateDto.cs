namespace Fashi.Dtos.Benefit
{
    public class BenefitUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? IconUrl { get; set; }
    }
}
