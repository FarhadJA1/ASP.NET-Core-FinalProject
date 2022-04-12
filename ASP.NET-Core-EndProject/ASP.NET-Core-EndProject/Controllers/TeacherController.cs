using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers =await _context.Teachers.ToListAsync();

            TeacherVM teacherVM = new TeacherVM()
            {
                Teachers=teachers,
            };
            return View(teacherVM);
        }
        public async Task<IActionResult> TeacherDetails(int id)
        {
            Teacher teacher = await _context.Teachers
                .Where(m=>m.Id == id)
                .Include(m=>m.TeacherContacts)
                .Include(m=>m.TeacherDetails)
                .Include(m => m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .FirstOrDefaultAsync();
            
           
            TeacherDetailsVM teacherDetailsVM = new TeacherDetailsVM()
            {
                Teacher=teacher,

            };
            return View(teacherDetailsVM);
        }
    }
}
