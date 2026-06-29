using Fashi.Models;

namespace Fashi.Areas.Admin.ViewModels.ProductVm
{
    public class UpdateProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Size { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> NewImages { get; set; }
        public List<int> DeleteImages { get; set; } = new List<int>();
        public List<ProductImage> ExistingImages { get; set; }=new List<ProductImage>();
    }
}
