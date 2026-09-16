namespace Fashi.Dtos.SosialMedia
{
    public class SosialMediaCreateDto
    {
        public string SosialMediaLink { get; set; }
        public string Icon { get; set; }

        public IFormFile ImageUrl { get; set; }
    }
}
