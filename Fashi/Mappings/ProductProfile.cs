using AutoMapper;
using Fashi.Dtos.Product;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ImageMain, o => o.MapFrom(s => s.ProductImages.FirstOrDefault(pi => pi.IsMain).ImageUrl))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));
           
        }
    }
}
