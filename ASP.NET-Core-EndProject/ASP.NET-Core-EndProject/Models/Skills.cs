using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class Skills:BaseEntity
    {
        public string Name { get; set; }
        public List<TeacherSkills> TeacherSkills { get; set; }
    }
}
