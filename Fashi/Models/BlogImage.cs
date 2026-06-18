using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class BlogImage:BaseEntity
    {
  
        public string  Image { get; set; }
        [NotMapped]
        public IFormFile ImgUrl { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
