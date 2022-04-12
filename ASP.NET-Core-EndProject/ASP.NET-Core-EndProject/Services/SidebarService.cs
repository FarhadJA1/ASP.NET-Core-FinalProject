using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Services
{
    public class SidebarService
    { 
        private readonly AppDbContext _context;
        public SidebarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Advert> GetAdvert()
        {
            Advert advert = await _context.Adverts.FirstOrDefaultAsync();
            return advert;
        }
        public async Task<List<Tag>> GetTags()
        {
            List<Tag> tags = await _context.Tags.ToListAsync();
            return tags;
        }
        public async Task<List<Blog>> GetBlogs()
        {
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            return blogs;
        }
        public async Task<List<CourseCategory>> GetCourseCategoriesAsync()
        {
            List<CourseCategory> courseCategories = await _context.CourseCategories.ToListAsync();
            return courseCategories;
        }
    }
}
