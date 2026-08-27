using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class SosialMedia: BaseEntity    
    {
    
        public string SosialMediaLink { get; set; }
        public string Icon { get; set; }
        [NotMapped]
        public IFormFile ImageUrl { get; set; }
        public string Image { get; set; }
     
    }
}
