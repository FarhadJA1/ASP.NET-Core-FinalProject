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
    public class ProTeacherController : Controller
    {
        private readonly AppDbContext _context;
        public ProTeacherController(AppDbContext context)
        {
            _context = context;
           
        }

        public async Task<IActionResult> Index()
        {
            List<ProTeacher> proTeachers =await _context.ProTeachers.Where(m=>m.IsDelete==false).OrderByDescending(m => m.Id).ToListAsync();
            return View(proTeachers);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProTeacher proTeacher)
        {
            if (!ModelState.IsValid) return View();
            await _context.ProTeachers.AddAsync(proTeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ProTeacher proTeacher = await _context.ProTeachers.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (proTeacher == null) return NotFound();
            proTeacher.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            ProTeacher proTeacher = await _context.ProTeachers
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            if (proTeacher == null) return NotFound();
            return View(proTeacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,ProTeacher proTeacher)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong");
            }

            if (id != proTeacher.Id) return BadRequest();

            ProTeacher dbProTeacher = await _context.ProTeachers
                .Where(m => m.Id == proTeacher.Id)
                .FirstOrDefaultAsync();

            dbProTeacher.Title = proTeacher.Title;
            dbProTeacher.Description = proTeacher.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Detail(int id)
        {
            ProTeacher proTeacher = await _context.ProTeachers.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(proTeacher);
        }
    }
}
