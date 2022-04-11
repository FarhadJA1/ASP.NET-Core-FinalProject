using ASP.NET_Core_EndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<ProTeacher> ProTeachers { get; set; }
        public Welcome Welcome { get; set; }
        public List<Course> Courses { get; set; }
        public Video Video { get; set; }
        public List<NoticePanel> NoticePanel { get; set; }
        public List<Event> Events { get; set; }
        public Testimonial Testimonial { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
