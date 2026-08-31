namespace Fashi.Models
{
    public class Sale:BaseEntity
    {
      
        public DateTime SaleTime { get; set; }
        public decimal Total { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
