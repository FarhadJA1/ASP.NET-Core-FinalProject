using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class TeacherSkills:BaseEntity
    {
        public int SkillsId { get; set; }
        public Skills Skills { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int Percent { get; set; }
    }
}
