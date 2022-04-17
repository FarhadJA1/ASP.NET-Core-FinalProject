using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;
        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(LayoutVM layoutVM)
        {

            Subscribe subscribe = new Subscribe()
            {
                Email=layoutVM.Subscribe.Email
            };
            await _context.Subscribers.AddAsync(subscribe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
