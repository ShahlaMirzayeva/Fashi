using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class HomeBanner:BaseEntity
    {
     
        public string Title { get; set; }
        public string  LittleTitle { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
