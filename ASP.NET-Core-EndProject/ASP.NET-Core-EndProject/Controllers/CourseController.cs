using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Courses.Where(m => m.IsDelete == false).ToListAsync();
            
            CourseVM courseVM = new CourseVM()
            {
                Courses=courses,
            };
            return View(courseVM);
        }
        public async Task<IActionResult> CourseDetails(int id)
        {
            Course course = await _context.Courses.Where(m=>m.Id==id).Include(m => m.CourseFeatures).FirstOrDefaultAsync();
            List<CourseCategory> courseCategories = await _context.CourseCategories.Where(m => m.IsDelete == false).ToListAsync();
            Advert advert = await _context.Adverts.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<Blog> blogs = await _context.Blogs.Where(m => m.IsDelete == false).ToListAsync();
            List<Tag> tags = await _context.Tags.Where(m => m.IsDelete == false).ToListAsync();

            CourseDetailsVM courseDetailsVM = new CourseDetailsVM()
            {
                Course=course,
                CourseCategories=courseCategories,
                Advert=advert,
                Blogs=blogs,
                Tags=tags,
            };
            return View(courseDetailsVM);
        }
        

    }
}
