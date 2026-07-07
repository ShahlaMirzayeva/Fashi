using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Models
{
    public class ProductImage:BaseEntity
    {

        public string ImageUrl { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool  IsMain { get; set; }

    }
}
