using Fashi.Models;

namespace Fashi.Areas.Admin.ViewModels.BlogVm
{
    public class UpdateBlogVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }

        public DateTime BlogCreateTime { get; set; }
        public int CommentCount { get; set; }
        public int BlogCategoryId { get; set; }
        public List<IFormFile>? NewImages { get; set; }
        public List<int> DeleteImagesIds { get; set; } = new List<int>();
        public List<BlogImage> ExistingImages { get; set; } = new List<BlogImage>();
    }
}
