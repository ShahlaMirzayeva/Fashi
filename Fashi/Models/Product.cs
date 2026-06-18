namespace Fashi.Models
{
    public class Product:BaseEntity
    {
  
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool SoftDelete { get; set; } = false;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; }
        public string Size { get; set; }
        public string LikeIcon { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
       
    }
}
