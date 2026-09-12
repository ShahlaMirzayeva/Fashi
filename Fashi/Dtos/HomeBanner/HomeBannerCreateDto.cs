namespace Fashi.Dtos.HomeBanner
{
    public class HomeBannerCreateDto
    {
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }

        public IFormFile Photo { get; set; }
    }
}
