namespace Fashi.Models
{
    public class Sale:BaseEntity
    {
      
        public DateTime SaleTime { get; set; }
        public double Total { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
