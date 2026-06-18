using Fashi.Models;

namespace Fashi.ViewModels
{
    public class BlogVM
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Blog? Blog { get; set; }
        public IEnumerable<BlogCategory>? BlogCategories { get; set; }
        public IEnumerable<BlogImage> BlogImages { get; set; }
    }
}
