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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index(int page = 1, int take = 6)
        {
            List<Event> events = await _context.Events
                .Skip((page - 1) * take)
                .Take(take)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            int count = await GetPageCount(take);

            Paginate<Event> pagination = new Paginate<Event>(events, page, count);

            return View(pagination);
        }
        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Events.CountAsync();
            return (int)Math.Ceiling((decimal)count / take);
        }
        public async Task<IActionResult> EventDetails(int id)
        {
            Event courseEvent = await _context.Events
                .Where(m=>m.Id==id && m.IsDelete==false)
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
