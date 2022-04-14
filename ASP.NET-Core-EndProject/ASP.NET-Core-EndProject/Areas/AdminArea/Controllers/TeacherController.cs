using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EndProject.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
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

    }
}
