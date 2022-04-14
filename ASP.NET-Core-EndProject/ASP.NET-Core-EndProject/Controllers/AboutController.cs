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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            Welcome welcome = await _context.Welcome.Where(m=>m.IsDelete==false).FirstOrDefaultAsync();
            List<Teacher> teachers = await _context.Teachers.Where(m => m.IsDelete == false).ToListAsync();
            Video video = await _context.Video.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<NoticePanel> noticePanel = await _context.NoticePanel.Where(m => m.IsDelete == false).ToListAsync();
            Testimonial testimonial = await _context.Testimonials.Where(m => m.IsDelete == false).FirstOrDefaultAsync();

            AboutVM aboutVM = new AboutVM()
            {
                Welcome=welcome,
                Teachers=teachers,
                Video = video,
                NoticePanel = noticePanel,
                Testimonial = testimonial,
            };
            return View(aboutVM);
        }
    }
}
