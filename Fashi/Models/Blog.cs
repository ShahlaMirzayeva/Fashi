namespace Fashi.Models
{
    public class Blog:BaseEntity
    {
       
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }
        
        public DateTime BlogCreateTime { get; set; }
        public int CommentCount { get; set; }

        public ICollection<BlogImage> BlogImages { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}
