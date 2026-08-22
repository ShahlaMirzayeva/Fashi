namespace Fashi.Dtos.Blog
{
    public class BlogDto
    {
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }
        public DateTime BlogCreateTime { get; set; }
        public int CommentCount { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public string? ImageMain { get; set; }
    }
}
