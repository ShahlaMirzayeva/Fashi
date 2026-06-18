using Microsoft.AspNetCore.Identity;

namespace Fashi.Models
{
    public class AppUser:IdentityUser
    {
        public string  UserName { get; set; }
        public string  Address { get; set; }
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        
    }
}
