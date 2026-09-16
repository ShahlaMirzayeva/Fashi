namespace Fashi.Dtos.SosialMedia
{
    public class SosialMediaUpdateDto
    {
        public int Id { get; set; }
        public string SosialMediaLink { get; set; }
        public string Icon { get; set; }

        public IFormFile ImageUrl { get; set; }
    }
}
