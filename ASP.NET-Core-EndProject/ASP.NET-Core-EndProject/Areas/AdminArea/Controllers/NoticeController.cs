using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    
    [Area("AdminArea")]
    public class NoticeController : Controller
    {
        private readonly AppDbContext _context;
        public NoticeController(AppDbContext context)
        {
            _context = context;
           
        }
        public async Task<IActionResult> Index()
        {
            List<NoticePanel> noticePanel = await _context.NoticePanel
                .Where(m => m.IsDelete == false)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
           
            return View(noticePanel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticePanel noticePanel)
        {
            if (!ModelState.IsValid) return View();
            await _context.NoticePanel.AddAsync(noticePanel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            NoticePanel notice = await _context.NoticePanel.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (notice == null) return NotFound();
            notice.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            NoticePanel notice = await _context.NoticePanel
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            if (notice == null) return NotFound();
            return View(notice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, NoticePanel noticePanel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong");
            }

            if (id != noticePanel.Id) return BadRequest();

            NoticePanel dbNotice = await _context.NoticePanel
                .Where(m => m.Id == noticePanel.Id)
                .FirstOrDefaultAsync();

            dbNotice.Date = noticePanel.Date;
            dbNotice.Notice = noticePanel.Notice;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Detail(int id)
        {
            NoticePanel noticePanel = await _context.NoticePanel.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(noticePanel);
        }
    }
}
