using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BlogVm;
using Fashi.Areas.Admin.ViewModels.ProductVm;
using Fashi.Dtos.Blog;
using Fashi.Dtos.Product;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class BlogProfile:Profile
    {

        public BlogProfile()
        {
            CreateMap<CreateBlogVm, BlogCreateDto>();
            CreateMap<UpdateBlogVm, BlogUpdateDto>();

            CreateMap<Blog, UpdateBlogVm>()
               
                .ForMember(dest => dest.ExistingImages, opt => opt.MapFrom(src => src.BlogImages));


            CreateMap<Blog, BlogDto>().
           ForMember(d => d.ImageMain, o => o.MapFrom(s =>
           s.BlogImages.Any(bi => bi.IsMain == true)
               ? s.BlogImages.First(bi => bi.IsMain == true).Image
               : (s.BlogImages.Any() ? s.BlogImages.First().Image : null)))
       .ForMember(d => d.BlogCategoryName, o => o.MapFrom(s => s.BlogCategory.Name));
        
            CreateMap<BlogCreateDto,Blog>()
                .ForMember(d => d.BlogImages, o => o.Ignore());

            CreateMap<BlogUpdateDto,Blog>().
                ForMember(d => d.BlogImages, o => o.Ignore());

        }
       

    }
}
