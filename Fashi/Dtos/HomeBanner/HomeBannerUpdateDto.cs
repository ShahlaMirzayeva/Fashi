namespace Fashi.Dtos.HomeBanner
{
    public class HomeBannerUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }

        public IFormFile Photo { get; set; }
    }
}
