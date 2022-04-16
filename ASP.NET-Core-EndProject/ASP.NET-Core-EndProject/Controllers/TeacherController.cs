using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.Utilities.Pagination;
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
        public async Task<IActionResult> Index(int page = 1, int take = 8)
        {
            List<Teacher> teachers =await _context.Teachers
                .Where(m => m.IsDelete == false)
                .Skip((page - 1) * take)
                .Take(take)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            int count = await GetPageCount(take);

            Paginate<Teacher> pagination = new Paginate<Teacher>(teachers, page, count);

            return View(pagination);
        }
        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Teachers.CountAsync();
            return (int)Math.Ceiling((decimal)count / take);
        }
        public async Task<IActionResult> TeacherDetails(int id)
        {
            Teacher teacher = await _context.Teachers
                .Where(m=>m.Id == id && m.IsDelete == false)
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
