using AutoMapper;
using Fashi.Services.BlogServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService; 
            _mapper = mapper;
        }
        public IActionResult Index()
        {var blog = _blogService.GetBlogAllAsync();
            return View(blog);
        }
    }
}
