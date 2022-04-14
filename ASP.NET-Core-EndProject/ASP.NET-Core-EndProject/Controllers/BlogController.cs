using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
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
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.Where(m => m.IsDelete == false).ToListAsync();

            BlogVM blogVM = new BlogVM()
            {
                Blogs=blogs,
            };
            return View(blogVM);
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
