using ASP.NET_Core_EndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels
{
    public class AboutVM
    {
        public Welcome Welcome { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Testimonial Testimonial { get; set; }
        public Video Video { get; set; }
        public List<NoticePanel> NoticePanel { get; set; }
    }
}
