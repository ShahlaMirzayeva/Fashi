using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class DealOfWeek:BaseEntity
    {
      
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DealofTime { get; set; }
        public double Price { get; set; }
        public string  Image { get; set; }
        [NotMapped]
        public IFormFile ImgUrl { get; set; }
    }
}
