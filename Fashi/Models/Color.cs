namespace Fashi.Models
{
    public class Color:BaseEntity
    {
    
        public string ColorName { get; set; }

        public virtual ICollection<ColorProduct> ColorProducts { get; set; }

        
    }
}
