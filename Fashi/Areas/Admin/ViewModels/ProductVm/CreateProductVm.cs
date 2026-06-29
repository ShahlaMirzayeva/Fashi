namespace Fashi.Areas.Admin.ViewModels.ProductVm
{
    public class CreateProductVm
    {
        public string  Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string  Size { get; set; }
        public int CategoryId { get; set; }
        public string LikeIcon { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
