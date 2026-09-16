using System.ComponentModel.DataAnnotations.Schema;

namespace Fashi.Areas.Admin.ViewModels.SosialMediaVm
{
    public class UpdateSosialMediaVm
    {
        public int Id { get; set; }
        public string SosialMediaLink { get; set; }
        public string Icon { get; set; }
      
        public IFormFile? ImageUrl { get; set; }
       
    }
}
