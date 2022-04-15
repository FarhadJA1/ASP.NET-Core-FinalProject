using ASP.NET_Core_EndProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels.Admin
{
    public class EventCreateVM
    {
        [Required]
        public Event Event { get; set; }
        [Required]
        public List<EventSpeaker> EventSpeakers { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
