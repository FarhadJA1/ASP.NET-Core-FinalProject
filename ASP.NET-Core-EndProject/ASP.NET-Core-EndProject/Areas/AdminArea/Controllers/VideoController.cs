using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class VideoController : Controller
    {
        private readonly AppDbContext _context;
        public VideoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Video video = await _context.Video.FirstOrDefaultAsync();
            return View(video);
        }
        public async Task<IActionResult> Update(int id)
        {
            Video video = await _context.Video.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (video == null) return NotFound();
            return View(video);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Video video)
        {
            if (id != video.Id) return BadRequest();
            Video dbVideo = await _context.Video.Where(m => m.Id == video.Id).FirstOrDefaultAsync();
            dbVideo.Link = video.Link;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
