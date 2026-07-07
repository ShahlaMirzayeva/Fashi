namespace Fashi.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Size { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? ImageMain { get; set; }
    }
}
