using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EventController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public EventController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            List<Event> events = await _context.Events.Where(m => m.IsDelete == false).OrderByDescending(m => m.Id).ToListAsync();
            
            return View(events);
        }
        public async Task<IActionResult> Create()
        {
            List<EventSpeaker> eventSpeakers = await _context.EventSpeakers.Include(m=>m.Teacher).ToListAsync();

            EventCreateVM eventCreateVM = new EventCreateVM()
            {
                EventSpeakers=eventSpeakers
            };
            return View(eventCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateVM eventCreateVM)
        {
            return Ok();
        }
    }
}
