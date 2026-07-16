namespace Fashi.Dtos.Product
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Size { get; set; }
        public int CategoryId { get; set; }
        public List<int> ColorIds { get; set; } = new List<int>();
        public List<IFormFile>? NewImages { get; set; }


        public List<int> DeleteImageIds { get; set; } = new();
    }
}
