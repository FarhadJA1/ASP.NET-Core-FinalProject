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
            List<Slider> sliders = await _context.Slider.ToListAsync();
            List<ProTeacher> proTeachers = await _context.ProTeachers.ToListAsync();
            Welcome welcome = await _context.Welcome.FirstOrDefaultAsync();
            List<Course> courses = await _context.Courses.ToListAsync();
            Video video = await _context.Video.FirstOrDefaultAsync();
            List<NoticePanel> noticePanel =await _context.NoticePanel.ToListAsync();
            List<Event> events = await _context.Events.ToListAsync();
            Testimonial testimonial = await _context.Testimonials.FirstOrDefaultAsync();
            List<Blog> blogs = await _context.Blogs.ToListAsync();

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
