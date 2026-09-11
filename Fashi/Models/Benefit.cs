using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class Benefit:BaseEntity
    {
       
        public string? Icon { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
