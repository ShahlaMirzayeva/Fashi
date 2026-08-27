using AutoMapper;
using Fashi.Dtos.Blog;
using Fashi.Models;

namespace Fashi.Mappings
{
    public class BlogProfile:Profile
    {

        public BlogProfile()
        {
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
