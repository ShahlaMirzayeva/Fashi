namespace Fashi.Models
{
    public class Category:BaseEntity
    {
   
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; }
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
