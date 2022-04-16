using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Helpers;
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

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs
                .Where(m => m.IsDelete == false)
                .OrderByDescending(m => m.Id)
                .ToListAsync();


            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM blogCreateVM)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Title"].ValidationState == ModelValidationState.Invalid) return View();

            if (!blogCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (blogCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + blogCreateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/blog", filename);
            string postPath = Helper.GetPath(_environment.WebRootPath, "assets/img/post", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blogCreateVM.Photo.CopyToAsync(stream);
            }
            

            Blog blog = new Blog()
            {
                Image = filename,
                Description = blogCreateVM.Description,
                Title = blogCreateVM.Title,
                From = blogCreateVM.From,
                Date = blogCreateVM.Date,
                CommentCount = blogCreateVM.CommentCount,
                PostImage = filename,
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Blog blog = await _context.Blogs.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (blog == null) return NotFound();
            string path = Path.Combine(_environment.WebRootPath, "assets/img/blog", blog.Image);
            string postPath = Path.Combine(_environment.WebRootPath, "assets/img/post", blog.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            if (System.IO.File.Exists(postPath))
            {
                System.IO.File.Delete(postPath);
            }
            blog.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _context.Blogs.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (blog == null) return NotFound();
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BlogUpdateVM blogUpdateVM)
        {

            if (!blogUpdateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (blogUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
            }
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid
                || ModelState["Description"].ValidationState == ModelValidationState.Invalid
                || ModelState["CommentCount"].ValidationState == ModelValidationState.Invalid
                || ModelState["Date"].ValidationState == ModelValidationState.Invalid
                || ModelState["From"].ValidationState == ModelValidationState.Invalid
                || ModelState["Title"].ValidationState == ModelValidationState.Invalid) return View();
            

            if (id != blogUpdateVM.Id) return BadRequest();

            Blog dbBlog = await _context.Blogs.Where(m => m.Id == blogUpdateVM.Id).FirstOrDefaultAsync();

            string filename = Guid.NewGuid().ToString() + "_" + blogUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/blog", filename);
            string postPath = Helper.GetPath(_environment.WebRootPath, "assets/img/post", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blogUpdateVM.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_environment.WebRootPath, "assets/img/blog", dbBlog.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbBlog.Image = filename;
            dbBlog.CommentCount = blogUpdateVM.CommentCount;
            dbBlog.Date = blogUpdateVM.Date;
            dbBlog.Description = blogUpdateVM.Description;
            dbBlog.PostImage = filename;
            dbBlog.Title = blogUpdateVM.Title;
            dbBlog.From = blogUpdateVM.From;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Blog blog = await _context.Blogs.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(blog);
        }
    }
}
