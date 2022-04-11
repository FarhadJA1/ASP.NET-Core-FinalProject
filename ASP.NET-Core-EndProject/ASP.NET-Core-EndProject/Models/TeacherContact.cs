using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class TeacherContact:BaseEntity
    {
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string SkypeAddress { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
