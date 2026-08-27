namespace Fashi.Dtos.Blog
{
    public class BlogUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }
        public DateTime BlogCreateTime { get; set; }
        public int CommentCount { get; set; }
        public int BlogCategoryId { get; set; }
        public List<IFormFile>? NewImages { get; set; }
        public List<int> DeleteImagesIds { get; set; } = new();
    }
}
