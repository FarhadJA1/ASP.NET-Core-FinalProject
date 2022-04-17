using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Slider
                .Where(m => !m.IsDelete)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();
            
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderVM sliderVM)
        {
            if(!ModelState.IsValid) return View(sliderVM);

            if (!sliderVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (sliderVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + sliderVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/slider", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await sliderVM.Photo.CopyToAsync(stream);
            }

            string desc = sliderVM.Description;
            string title = sliderVM.Title;

            Slider slider = new Slider()
            {
                Image=filename,
                Description=desc,
                Title=title
            };
            await _context.Slider.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider =await _context.Slider.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (slider == null) return NotFound();
            string path = Path.Combine(_environment.WebRootPath, "assets/img/slider", slider.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            slider.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Slider slider = await _context.Slider.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (slider == null) return NotFound();
            return View(slider);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Slider slider)
        {

            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (slider.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
            }
            if (!ModelState.IsValid) return View();

            if (id != slider.Id) return BadRequest();

            Slider dbslider = await _context.Slider.Where(m => m.Id == slider.Id).FirstOrDefaultAsync();

            string filename = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/slider",filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_environment.WebRootPath, "assets/img/blog", dbslider.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbslider.Image = filename;
            dbslider.Description = slider.Description;
            dbslider.Title = slider.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Slider slider = await _context.Slider.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(slider);
        }
    }
}
