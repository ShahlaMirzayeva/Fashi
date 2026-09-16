namespace Fashi.Areas.Admin.ViewModels.BlogVm
{
    public class CreateBlogVm
    {
        public string Title { get; set; }
        public string LittleTitle { get; set; }
        public string Description { get; set; }

        public DateTime BlogCreateTime { get; set; }
        public int CommentCount { get; set; }
        public int BlogCategoryId { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
