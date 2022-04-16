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
            List<Teacher> teachers = await _context.Teachers.Where(m => m.IsDelete == false).ToListAsync();


            EventCreateVM eventCreateVM = new EventCreateVM()
            {
                EventSpeakers=eventSpeakers,
                Teachers=teachers
            };
            return View(eventCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateVM eventCreateVM)
        {
            if (!ModelState.IsValid) return View(eventCreateVM);

            if (!eventCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View(eventCreateVM);
            }
            if (eventCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View(eventCreateVM);
            }

            string filename = Guid.NewGuid().ToString() + "_" + eventCreateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/event", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await eventCreateVM.Photo.CopyToAsync(stream);
            }

            
            List<Teacher> list = new List<Teacher>();

            bool isChecked = eventCreateVM.Teachers.Any(m => m.isChecked == true);

            if (isChecked==true)
            {
                list.AddRange(eventCreateVM.Teachers.Where(m => m.isChecked==true));
            }
             
            

            Event @event = new Event()
            {
                Image = filename,
                Date = eventCreateVM.Event.Date,
                Title = eventCreateVM.Event.Title,
                Time = eventCreateVM.Event.Time,
                Location =eventCreateVM.Event.Location,
                Description =eventCreateVM.Event.Description,
            };
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();

            foreach (var item in list)
            {
                EventSpeaker eventSpeaker = new EventSpeaker
                {
                    EventId = @event.Id,
                    TeacherId = item.Id
                };
                await _context.EventSpeakers.AddAsync(eventSpeaker);
            }
            
           
            await _context.SaveChangesAsync();
            

            return RedirectToAction(nameof(Index));
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Event @event = await _context.Events.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (@event == null) return NotFound();
            if (@event.Id != id) return BadRequest();
            string path = Path.Combine(_environment.WebRootPath, "assets/img/event", @event.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            @event.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Event @event = await _context.Events.Where(m=>m.Id==id).Include(m => m.EventSpeakers).ThenInclude(m=>m.Teacher).FirstOrDefaultAsync();
            List<EventSpeaker> eventSpeakers = await _context.EventSpeakers.Where(m => m.EventId == id).Include(m=>m.Teacher).ToListAsync();
            List<Teacher> teachers = await _context.Teachers.Where(m => m.IsDelete == false).ToListAsync();
            if (@event == null) return NotFound();
            if (@event.Id != id) return BadRequest();
            EventUpdateVM eventUpdateVM = new EventUpdateVM()
            {
                Event = @event,
                EventSpeakers = eventSpeakers,
                Teachers=teachers
            };
            return View(eventUpdateVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,EventUpdateVM eventUpdateVM)
        {
            if (!eventUpdateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (eventUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
            }
            if (!ModelState.IsValid) return View();

            if (id != eventUpdateVM.Id) return BadRequest();

            Event dbEvent = await _context.Events.Where(m => m.Id == eventUpdateVM.Id).FirstOrDefaultAsync();

            string filename = Guid.NewGuid().ToString() + "_" + eventUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_environment.WebRootPath, "assets/img/event", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await eventUpdateVM.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_environment.WebRootPath, "assets/img/event", dbEvent.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbEvent.Image = filename;
            dbEvent.Date = eventUpdateVM.Event.Date;
            dbEvent.Description = eventUpdateVM.Event.Description;
            dbEvent.Location = eventUpdateVM.Event.Location;
            dbEvent.Time = eventUpdateVM.Event.Time;
            dbEvent.Title = eventUpdateVM.Event.Title;

            List<Teacher> list = new List<Teacher>();

            bool isChecked = eventUpdateVM.Teachers.Any(m => m.isChecked == true);

            if (isChecked == true)
            {
                list.AddRange(eventUpdateVM.Teachers.Where(m => m.isChecked == true));
            }

            foreach (var item in list)
            {
                EventSpeaker eventSpeaker = new EventSpeaker
                {
                    EventId = dbEvent.Id,
                    TeacherId = item.Id
                };
               
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detail(int id)
        {
            Event @event = await _context.Events.Where(m => m.Id == id).Include(m => m.EventSpeakers).ThenInclude(m=>m.Teacher).FirstOrDefaultAsync();
            return View(@event);
        }

    }
}
