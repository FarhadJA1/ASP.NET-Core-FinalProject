using ASP.NET_Core_EndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels
{
    public class TeacherDetailsVM
    {
        public Teacher Teacher { get; set; }
        public List<Skills> Skills { get; set; }
        public List<TeacherSkills> TeacherSkills { get; set; }


    }
}
