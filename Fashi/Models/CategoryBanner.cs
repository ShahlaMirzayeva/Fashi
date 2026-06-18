using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class CategoryBanner:BaseEntity  
    {

        public string Name { get; set; }
        public string  Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
