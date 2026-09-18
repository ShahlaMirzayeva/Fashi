using AutoMapper;
using Fashi.Dtos.Blog;
using Fashi.Models;
using Fashi.Repositories.BlogRepo;
using Fashi.Services.FileServ;

namespace Fashi.Services.BlogServ
{
    public class BlogService : IBlogService
    {private readonly IBlogRepository _blogRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;   
        public BlogService(IBlogRepository blogRepository, IFileService fileService, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task AddBlogAsync(BlogCreateDto blogCreateDto, List<IFormFile> blogImages)
        {if (blogImages != null && blogImages.Count > 6) { 
            throw new Exception("You can upload a maximum of 6 images for the blog.");
            
            }
        var blog = _mapper.Map<Blog>(blogCreateDto);
            blog.BlogImages=new List<BlogImage>();
            if(blogImages != null)
            {
                foreach (var image in blogImages)
                {
                    string imageUrl = await _fileService.UploadFileAsync(image, "blogs");
                    blog.BlogImages.Add(new BlogImage { Image = imageUrl });
              

                }
            }
           
            await _blogRepository.AddAsync(blog);
            await _blogRepository.SaveAsync();

        }

        public async Task DeleteBlogAsync(int id)
        {var blog = await _blogRepository.GetByIdAsync(id,blog => blog.BlogImages);
            if(blog == null)
            {
                throw new Exception("Blog not found.");
            }

            foreach (var image in blog.BlogImages)
            {
                _fileService.DeleteImage(image.Image);
            }
         await _blogRepository.DeleteAsync(id);
            await _blogRepository.SaveAsync();
        }

        public async Task<IEnumerable<BlogDto>> GetBlogAllAsync()
        {
           var blogs = await _blogRepository.GetAllAsync(blog => blog.BlogImages, blog => blog.BlogCategory);
            return _mapper.Map<IEnumerable<BlogDto>>(blogs);
        }

        public async Task<BlogDto> GetBlogByIdAsync(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id, blog => blog.BlogImages);
            if (blog == null)
            {
                throw new Exception("Blog not found.");
            }
            return _mapper.Map<BlogDto>(blog);
        }

        public async Task UpdateBlogAsync(BlogUpdateDto blogUpdateDto)
        {var blog = await _blogRepository.GetByIdAsync(blogUpdateDto.Id, blog => blog.BlogImages);
            if(blog == null)
            {
                throw new Exception("Blog not found.");
            }
            _mapper.Map(blogUpdateDto, blog);
            if (blogUpdateDto.DeleteImagesIds.Any())
            {
                var imagesToDelete = blog.BlogImages.Where(img => blogUpdateDto.DeleteImagesIds.Contains(img.Id)).ToList();
                foreach (var image in imagesToDelete)
                {
                    _fileService.DeleteImage(image.Image);
                    blog.BlogImages.Remove(image);
                }
            }
            if (blogUpdateDto.NewImages.Any())
            {
                foreach (var newImage in blogUpdateDto.NewImages)
                {
                    string imageUrl = await _fileService.UploadFileAsync(newImage, "blogs");
                    blog.BlogImages.Add(new BlogImage { Image = imageUrl });
                }
            }
            
            await _blogRepository.UpdateAsync(blog);
            await _blogRepository.SaveAsync();
        }
    }
}
