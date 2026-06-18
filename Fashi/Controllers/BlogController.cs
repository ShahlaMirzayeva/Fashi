using Fashi.Data;
using Fashi.Models;
using Fashi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fashi.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            BlogVM blogVM = new BlogVM
            {
              Blogs=_context.Blogs.Include(b=>b.BlogImages).Include(b=>b.BlogCategory).Take(4),
              BlogCategories=_context.BlogCategories
            };
            return View(blogVM);
        }

        public async Task<IActionResult> BlogDetail(int? id)
        {
            if (id == null) return NotFound();
            var blog =await _context.Blogs.Include(b => b.BlogImages).Include(b => b.BlogCategory).FirstOrDefaultAsync(b=>b.Id==id);
           if(blog==null) return NotFound();
            BlogVM blogVM = new BlogVM
            {
                Blog=blog,
                BlogCategories=await _context.BlogCategories.ToListAsync()
            };
            if (blogVM == null) return NotFound();
            return View(blogVM);
        }

        public async Task<IActionResult> LoadMore(int skip=0,int take=4)
        {
            var blogs = await _context.Blogs
         .Include(b => b.BlogCategory)
         .Include(b => b.BlogImages)
         .OrderByDescending(b => b.Id)
         .Skip(skip)
         .Take(take)
         .ToListAsync();

            if (!blogs.Any()) return Content("");
            return PartialView("_BlogsPartialView",blogs);
        }
    }
}
