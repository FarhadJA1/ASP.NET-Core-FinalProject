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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<Event> events = await _context.Events.OrderByDescending(m=>m.Id).ToListAsync();

            EventVM eventVM = new EventVM()
            {
                Events=events,
            };
            return View(eventVM);
        }
        public async Task<IActionResult> EventDetails(int id)
        {
            Event courseEvent = await _context.Events
                .Where(m=>m.Id==id)
                .Include(m=>m.EventSpeakers)
                .ThenInclude(m=>m.Teacher)
                .FirstOrDefaultAsync();

            EventDetailsVM eventDetailsVM = new EventDetailsVM()
            {
                Event=courseEvent
            };
            return View(eventDetailsVM);
        }
    }
}
