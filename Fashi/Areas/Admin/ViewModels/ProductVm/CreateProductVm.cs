using System.ComponentModel.DataAnnotations;

namespace Fashi.Areas.Admin.ViewModels.ProductVm
{
    public class CreateProductVm
    {
        [Required (ErrorMessage = "Name is required")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }
        [Required(ErrorMessage = "Price is required")] 
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Discount is required")]
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "Size is required")]
        public string  Size { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
    
        [Required(ErrorMessage = "Image is required")]
        public List<IFormFile>? Images { get; set; }
        public List<int> ColorIds { get; set;  }=new List<int>();
    }
}
