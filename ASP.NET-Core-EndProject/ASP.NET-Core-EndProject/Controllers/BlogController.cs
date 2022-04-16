using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.Utilities.Pagination;
using ASP.NET_Core_EndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index(int page=1,int take=6)
        {
            List<Blog> blogs = await _context.Blogs
                .Where(m => m.IsDelete == false)
                .Skip((page-1)*take)
                .Take(take)
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            int count = await GetPageCount(take);

            Paginate<Blog> pagination = new Paginate<Blog>(blogs,page,count);

            return View(pagination);
        }
        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Blogs.CountAsync();
            return (int)Math.Ceiling((decimal)count / take);
        }
        

        public async Task<IActionResult> BlogDetails(int id)
        {
            Blog blog = await _context.Blogs.Where(m => m.Id == id).FirstOrDefaultAsync();

            BlogDetailVM blogDetailVM = new BlogDetailVM()
            {
                Blog=blog
            };
            return View(blogDetailVM);
        }
    }
}
