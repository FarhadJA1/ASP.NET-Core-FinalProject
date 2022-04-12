using ASP.NET_Core_EndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels
{
    public class SidebarVM
    {
        public List<Tag> Tags { get; set; }
        public List<Blog> Blogs { get; set; }
        public Advert Advert { get; set; }
        public List<CourseCategory> CourseCategories { get; set; }
    }
}
