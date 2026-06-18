namespace Fashi.Models
{
    public class SaleProduct:BaseEntity
    {
      
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }

        public int ProductId{ get; set; }
        public virtual Product Product { get; set; }
    }
}
