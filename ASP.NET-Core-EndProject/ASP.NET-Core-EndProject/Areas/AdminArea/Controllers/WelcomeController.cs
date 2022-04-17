using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Helpers;
using System.IO;
using static ASP.NET_Core_EndProject.Utilities.Helpers.Helper;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    
    [Area("AdminArea")]
    public class WelcomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public WelcomeController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            Welcome welcome = await _context.Welcome.FirstOrDefaultAsync();
            return View(welcome);
        }
        public async Task<IActionResult> Update(int id)
        {
            Welcome welcome = await _context.Welcome.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (welcome == null) return NotFound();
            return View(welcome);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Welcome welcome)
        {
            if (!welcome.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (welcome.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
            }
            if (!ModelState.IsValid) return View();

            if (id != welcome.Id) return BadRequest();

            Welcome dbWelcome = await _context.Welcome.Where(m => m.Id == welcome.Id).FirstOrDefaultAsync();

            string filename = Guid.NewGuid().ToString() + "_" + welcome.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/about", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await welcome.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_environment.WebRootPath, "assets/img/blog", dbWelcome.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbWelcome.Image = filename;
            dbWelcome.Description = welcome.Description;
            dbWelcome.Title = welcome.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
