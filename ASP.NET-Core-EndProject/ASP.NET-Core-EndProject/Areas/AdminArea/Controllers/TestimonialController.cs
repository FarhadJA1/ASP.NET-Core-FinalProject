using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    
    [Area("AdminArea")]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public TestimonialController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        public async Task<IActionResult> Index()
        {
            List<Testimonial> testimonials = await _context.Testimonials
                .Where(m=>m.IsDelete==false)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();
            if (testimonials == null) return NotFound();
            return View(testimonials);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonial testimonial)
        {
            if (!ModelState.IsValid) return View();

            if (!testimonial.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (testimonial.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + testimonial.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/testimonial", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await testimonial.Photo.CopyToAsync(stream);
            }

            testimonial.Image = filename;
            
            await _context.Testimonials.AddAsync(testimonial);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Testimonial testimonial = await _context.Testimonials.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (testimonial == null) return NotFound();
            string path = Path.Combine(_environment.WebRootPath, "assets/img/testimonial", testimonial.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            testimonial.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Testimonial testimonial = await _context.Testimonials.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (testimonial == null) return NotFound();
            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Testimonial testimonial)
        {

            if (!testimonial.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (testimonial.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
            }
            if (!ModelState.IsValid) return View();

            if (id != testimonial.Id) return BadRequest();

            Testimonial dbTestimonial = await _context.Testimonials.Where(m => m.Id == testimonial.Id).FirstOrDefaultAsync();

            string filename = Guid.NewGuid().ToString() + "_" + testimonial.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/testimonial", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await testimonial.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_environment.WebRootPath, "assets/img/blog", dbTestimonial.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbTestimonial.Image = filename;
            dbTestimonial.Description = testimonial.Description;
            dbTestimonial.Name = testimonial.Name;
            dbTestimonial.Profession = testimonial.Profession;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Testimonial testimonial = await _context.Testimonials.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(testimonial);
        }
    }
}
