namespace Fashi.Models
{
    public class BlogCategory:BaseEntity
    {
    
        public string Name { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
