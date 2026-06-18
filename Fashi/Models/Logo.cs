using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class Logo:BaseEntity
    {
       
        public string LogoIcon { get; set; }
        [NotMapped]
        public IFormFile LogoUrl { get; set; }
    }
}
