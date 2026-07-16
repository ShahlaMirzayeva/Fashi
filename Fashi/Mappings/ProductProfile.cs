using AutoMapper;
using Fashi.Areas.Admin.ViewModels.ProductVm;
using Fashi.Dtos.Product;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductVm, ProductCreateDto>();
            CreateMap<UpdateProductVm, ProductUpdateDto>();

            CreateMap<Product, UpdateProductVm>()
                .ForMember(dest=>dest.ColorIds, opt=>opt.MapFrom(src=>src.ColorProducts.Select(cp=>cp.ColorId)))
                .ForMember(dest=>dest.ExistingImages, opt=>opt.MapFrom(src=>src.ProductImages));

            CreateMap<Product, ProductDto>()
              .ForMember(d => d.ImageMain, o => o.MapFrom(s =>
            s.ProductImages.Any(pi => pi.IsMain)
                ? s.ProductImages.First(pi => pi.IsMain).ImageUrl
                : (s.ProductImages.Any() ? s.ProductImages.First().ImageUrl : null)))
        .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
        .ForMember(d=>d.MainColorName,o=>o.MapFrom(s=>s.ColorProducts.Any()?s.ColorProducts.First().Color.ColorName:null));
            CreateMap<ProductCreateDto, Product>()
                .ForMember(d=>d.ColorProducts,o=>o.Ignore())
                .ForMember(d=>d.ProductImages,o=>o.Ignore());
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(d=>d.ColorProducts,o=>o.Ignore())
                .ForMember(d=>d.ProductImages,o=>o.Ignore());
        }
    }
}
