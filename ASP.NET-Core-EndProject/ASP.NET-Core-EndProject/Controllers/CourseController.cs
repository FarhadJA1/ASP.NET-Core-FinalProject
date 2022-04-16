using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.Utilities.Pagination;
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
        public async Task<IActionResult> Index(int page = 1, int take = 6)
        {
            List<Course> courses = await _context.Courses
                .Where(m => m.IsDelete == false)
                .Skip((page - 1) * take)
                .Take(take)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            
            int count = await GetPageCount(take);
            Paginate<Course> pagination = new Paginate<Course>(courses, page, count);
            return View(pagination);
        }
        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Courses.CountAsync();
            return (int)Math.Ceiling((decimal)count / take);
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
        
        public async Task<IActionResult> Search(string course)
        {
            ViewData["GetCourses"] = course;

            if (!String.IsNullOrEmpty(course))
            {
                List<Course> courseQuery = await _context.Courses.Where(m => m.Title.Trim().ToLower().Contains(course.Trim().ToLower())).ToListAsync();
                return View(courseQuery);
            }
            return View();
        }
        

    }
}
