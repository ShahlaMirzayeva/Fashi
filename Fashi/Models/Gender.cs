namespace Fashi.Models
{
    public class Gender:BaseEntity
    {
    
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
