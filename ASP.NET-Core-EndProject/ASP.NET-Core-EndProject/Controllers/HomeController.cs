using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Slider.Where(m => m.IsDelete == false).ToListAsync();
            List<ProTeacher> proTeachers = await _context.ProTeachers.Where(m => m.IsDelete == false).ToListAsync();
            Welcome welcome = await _context.Welcome.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<Course> courses = await _context.Courses.Where(m => m.IsDelete == false).ToListAsync();
            Video video = await _context.Video.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<NoticePanel> noticePanel =await _context.NoticePanel.Where(m => m.IsDelete == false).ToListAsync();
            List<Event> events = await _context.Events.Where(m => m.IsDelete == false).ToListAsync();
            Testimonial testimonial = await _context.Testimonials.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<Blog> blogs = await _context.Blogs.Where(m => m.IsDelete == false).ToListAsync();

            HomeVM homeVM = new HomeVM()
            {
                Sliders = sliders,
                ProTeachers = proTeachers,
                Welcome=welcome,
                Courses=courses,
                Video=video,
                NoticePanel=noticePanel,
                Events=events,
                Testimonial=testimonial,
                Blogs=blogs
            };
            return View(homeVM);

        }

    }
}
