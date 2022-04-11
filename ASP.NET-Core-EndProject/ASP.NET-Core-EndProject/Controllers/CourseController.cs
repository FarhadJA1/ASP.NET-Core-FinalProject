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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Courses.ToListAsync();

            CourseVM courseVM = new CourseVM()
            {
                Courses=courses,
            };
            return View(courseVM);
        }
        public async Task<IActionResult> CourseDetails(int id)
        {
            Course course = await _context.Courses.Where(m=>m.Id==id).Include(m => m.CourseFeatures).FirstOrDefaultAsync();
            List<CourseCategory> courseCategories = await _context.CourseCategories.ToListAsync();

            CourseDetailsVM courseDetailsVM = new CourseDetailsVM()
            {
                Course=course,
                CourseCategories=courseCategories,
            };
            return View(courseDetailsVM);
        }

    }
}
