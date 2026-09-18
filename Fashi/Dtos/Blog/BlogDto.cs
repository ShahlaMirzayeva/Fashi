using Fashi.Models;

namespace Fashi.Dtos.Blog
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }
        public DateTime BlogCreateTime { get; set; }
        public int CommentCount { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public List<BlogImage> BlogImages { get; set; } = new();
        public string? ImageMain { get; set; }
    }
}
