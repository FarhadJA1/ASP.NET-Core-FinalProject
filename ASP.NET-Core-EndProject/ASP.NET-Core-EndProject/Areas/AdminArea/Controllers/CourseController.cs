using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    
    [Area("AdminArea")]
    public class CourseController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Courses
                .Where(m => m.IsDelete == false)
                .Include(m=>m.CourseCategory)
                .Include(m=>m.CourseFeatures)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();

            CourseListVM courseListVM = new CourseListVM()
            {
                Courses=courses,
            };
            return View(courseListVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateVM courseCreateVM)
        {
            if (!ModelState.IsValid) return View();

            if (!courseCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (courseCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + courseCreateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/course", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await courseCreateVM.Photo.CopyToAsync(stream);
            }

            Course course = new Course()
            {
                Image = filename,
                Title = courseCreateVM.Title,
                Description = courseCreateVM.Description,
                Apply = courseCreateVM.Apply,
                About = courseCreateVM.About,
                Certification = courseCreateVM.Certification,
                
            };
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            CourseFeatures courseFeatures = new CourseFeatures()
            {
                Starts=courseCreateVM.Starts,
                Duration=courseCreateVM.Duration,
                ClassDuration=courseCreateVM.ClassDuration,
                SkillLevel=courseCreateVM.SkillLevel,
                Language=courseCreateVM.Language,
                Students=courseCreateVM.Students,
                Assesment=courseCreateVM.Assesment,
                Price=courseCreateVM.Price,
                CourseId=course.Id
            };
            await _context.CourseFeatures.AddAsync(courseFeatures);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Course course = await _context.Courses.Where(m => m.Id == id).FirstOrDefaultAsync();
            CourseFeatures courseFeatures = await _context.CourseFeatures.Where(m => m.CourseId == course.Id).FirstOrDefaultAsync();
            if (course == null) return NotFound();
            string path = Path.Combine(_environment.WebRootPath, "assets/img/course", course.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            course.IsDelete = true;
            courseFeatures.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Course course = await _context.Courses.Where(m => m.Id == id).Include(m=>m.CourseFeatures).FirstOrDefaultAsync();
            if (course == null) return NotFound();

            CourseUpdateVM courseUpdateVM = new CourseUpdateVM()
            {
                About = course.About,
                Apply = course.Apply,
                Image = course.Image,
                Title = course.Title,
                Certification = course.Certification,
                Starts = course.CourseFeatures.Starts,
                Duration = course.CourseFeatures.Duration,
                ClassDuration = course.CourseFeatures.ClassDuration,
                Description = course.Description,
                SkillLevel = course.CourseFeatures.SkillLevel,
                Language = course.CourseFeatures.Language,
                Assesment = course.CourseFeatures.Assesment,
                Price = course.CourseFeatures.Price,
                Students = course.CourseFeatures.Students
                
            };
            return View(courseUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CourseUpdateVM courseUpdateVM)
        {

            if (!courseUpdateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (courseUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
            }
            if (!ModelState.IsValid) return View();

            if (id != courseUpdateVM.Id) return BadRequest();

            Course dbCourse = await _context.Courses.Where(m => m.Id == courseUpdateVM.Id).FirstOrDefaultAsync();

            string filename = Guid.NewGuid().ToString() + "_" + courseUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/course", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await courseUpdateVM.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_environment.WebRootPath, "assets/img/course", dbCourse.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbCourse.Image = filename;
            dbCourse.Title = courseUpdateVM.Title;
            dbCourse.Description = courseUpdateVM.Description;
            dbCourse.Certification = courseUpdateVM.Certification;
            dbCourse.Apply = courseUpdateVM.Apply;
            dbCourse.About = courseUpdateVM.About;
            dbCourse.CourseFeatures.Assesment = courseUpdateVM.Assesment;
            dbCourse.CourseFeatures.ClassDuration = courseUpdateVM.ClassDuration;
            dbCourse.CourseFeatures.Duration = courseUpdateVM.Duration;
            dbCourse.CourseFeatures.Language = courseUpdateVM.Language;
            dbCourse.CourseFeatures.SkillLevel = courseUpdateVM.SkillLevel;
            dbCourse.CourseFeatures.Students = courseUpdateVM.Students;
            dbCourse.CourseFeatures.Starts = courseUpdateVM.Starts;
            dbCourse.CourseFeatures.Price = courseUpdateVM.Price;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Course course = await _context.Courses.Where(m => m.Id == id).Include(m=>m.CourseFeatures).FirstOrDefaultAsync();
            return View(course);
        }




    }
}
