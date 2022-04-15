using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels;
using ASP.NET_Core_EndProject.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeacherController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = await _context.Teachers
                .Where(m => m.IsDelete == false)
                .Include(m=>m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();
            return View(teachers);
        }
        public async Task<IActionResult> Create()
        {
            List<Skills> skills = await _context.Skills.ToListAsync();

            TeacherCreateVM teacherCreateVM = new TeacherCreateVM()
            {
                Skills = skills
            };
            return View(teacherCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateVM teacherCreateVM)
        {
            if (!ModelState.IsValid) return View();

            if (!teacherCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (teacherCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            string filename = Guid.NewGuid().ToString() + "_" + teacherCreateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/teacher", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await teacherCreateVM.Photo.CopyToAsync(stream);
            }

            
            TeacherContact teacherContact = new TeacherContact()
            {
                Mail = teacherCreateVM.TeacherContact.Mail,
                SkypeAddress = teacherCreateVM.TeacherContact.SkypeAddress,
                Phone = teacherCreateVM.TeacherContact.Phone,
                TeacherId = teacherCreateVM.Id
                
            };
            await _context.TeacherContacts.AddAsync(teacherContact);

            TeacherDetail teacherDetail = new TeacherDetail()
            {
                Degree = teacherCreateVM.TeacherDetail.Degree,
                Experience = teacherCreateVM.TeacherDetail.Experience,
                Hobbies = teacherCreateVM.TeacherDetail.Hobbies,
                Faculty = teacherCreateVM.TeacherDetail.Faculty,
                TeacherId = teacherCreateVM.Id
                
            };
            await _context.TeacherDetails.AddAsync(teacherDetail);

            Teacher teacher = new Teacher()
            {
                Image = filename,
                Fullname = teacherCreateVM.Teacher.Fullname,
                Profession = teacherCreateVM.Teacher.Profession,
                About = teacherCreateVM.Teacher.About,
                TeacherDetails=teacherDetail,
                TeacherContacts=teacherContact

            };
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            Teacher lastTeacher = await _context.Teachers.OrderByDescending(m => m.Id).FirstOrDefaultAsync();

            int count = 0;

            foreach (var skills in teacherCreateVM.Skills)
            {
                TeacherSkills teacherSkills = new TeacherSkills()
                {
                    SkillsId = skills.Id,
                    TeacherId=lastTeacher.Id,
                    Percent = teacherCreateVM.Percent[count]
                };
                count++;
                await _context.TeacherSkills.AddAsync(teacherSkills);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Teacher teacher = await _context.Teachers.Where(m => m.Id == id).FirstOrDefaultAsync();
            TeacherContact teacherContact = await _context.TeacherContacts.Where(m => m.TeacherId == teacher.Id).FirstOrDefaultAsync();
            TeacherDetail teacherDetail = await _context.TeacherDetails.Where(m => m.TeacherId == teacher.Id).FirstOrDefaultAsync();
            TeacherSkills teacherSkills = await _context.TeacherSkills.Where(m => m.TeacherId == teacher.Id).FirstOrDefaultAsync();
            if (teacher == null) return NotFound();
            string path = Path.Combine(_environment.WebRootPath, "assets/img/teacher", teacher.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            teacher.IsDelete = true;
            teacherContact.IsDelete = true;
            teacherDetail.IsDelete = true;
            teacherSkills.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Teacher teacher = await _context.Teachers.Where(m => m.Id == id)
                .Include(m=>m.TeacherContacts)
                .Include(m=>m.TeacherDetails)
                .Include(m=>m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .FirstOrDefaultAsync();
            TeacherSkills teacherSkills = await _context.TeacherSkills.Where(m => m.TeacherId == teacher.Id).FirstOrDefaultAsync();
            TeacherContact teacherContact = await _context.TeacherContacts.Where(m => m.TeacherId == teacher.Id).FirstOrDefaultAsync();
            TeacherDetail teacherDetail = await _context.TeacherDetails.Where(m => m.Id == teacher.Id).FirstOrDefaultAsync();
            if (teacher == null) return NotFound();
            List<Skills> skills = await _context.Skills.ToListAsync();
            TeacherUpdateVM teacherUpdateVM = new TeacherUpdateVM()
            {
                Teacher=teacher,
                TeacherContact=teacherContact,
                TeacherDetail=teacherDetail,
                Percent=teacherSkills.Percent,
                Skills=skills,
            };

            return View(teacherUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,TeacherUpdateVM teacherUpdateVM)
        {
            if (!ModelState.IsValid) return View();

            if (!teacherUpdateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (teacherUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (id != teacherUpdateVM.Id) return BadRequest();
            Teacher dbTeacher = await _context.Teachers
                .Where(m => m.Id == teacherUpdateVM.Id)
                .Include(m=>m.TeacherContacts)
                .Include(m=>m.TeacherDetails)
                .Include(m=>m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .FirstOrDefaultAsync();
            
            string filename = Guid.NewGuid().ToString() + "_" + teacherUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/teacher", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await teacherUpdateVM.Photo.CopyToAsync(stream);
            }

            string lastImage = Path.Combine(_environment.WebRootPath, "assets/img/teacher", dbTeacher.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            

            dbTeacher.Image = filename;
            dbTeacher.Fullname = teacherUpdateVM.Teacher.Fullname;
            dbTeacher.About = teacherUpdateVM.Teacher.About;
            dbTeacher.Profession = teacherUpdateVM.Teacher.Profession;
            dbTeacher.TeacherContacts.Mail = teacherUpdateVM.TeacherContact.Mail;
            dbTeacher.TeacherContacts.Phone = teacherUpdateVM.TeacherContact.Phone;
            dbTeacher.TeacherContacts.SkypeAddress = teacherUpdateVM.TeacherContact.SkypeAddress;
            dbTeacher.TeacherDetails.Degree = teacherUpdateVM.TeacherDetail.Degree;
            dbTeacher.TeacherDetails.Experience = teacherUpdateVM.TeacherDetail.Experience;
            dbTeacher.TeacherDetails.Faculty = teacherUpdateVM.TeacherDetail.Faculty;
            dbTeacher.TeacherDetails.Hobbies = teacherUpdateVM.TeacherDetail.Hobbies;
            foreach (var teacherSkills in dbTeacher.TeacherSkills)
            {
                teacherSkills.Percent = teacherUpdateVM.Percent;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Teacher teacher = await _context.Teachers.Where(m => m.Id == id)
                .Include(m => m.TeacherContacts)
                .Include(m=>m.TeacherDetails)
                .Include(m=>m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .FirstOrDefaultAsync();
            return View(teacher);
        }
    }
}
