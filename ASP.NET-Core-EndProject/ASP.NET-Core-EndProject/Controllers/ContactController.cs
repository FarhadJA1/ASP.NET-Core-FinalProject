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
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync();

            ContactVM contactVM = new ContactVM()
            {
                Contact=contact
            };
            return View(contactVM);
        }
    }
}
