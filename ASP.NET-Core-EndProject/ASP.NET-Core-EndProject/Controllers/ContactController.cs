﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Controllers
{
    public class ContactController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
