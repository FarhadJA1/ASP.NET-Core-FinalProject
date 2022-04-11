using ASP.NET_Core_EndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels
{
    public class CourseDetailsVM
    {
        public Course Course { get; set; }
        public List<CourseCategory> CourseCategories { get; set; }
        public List<CourseFeatures> CourseFeatures { get; set; }
    }
}
