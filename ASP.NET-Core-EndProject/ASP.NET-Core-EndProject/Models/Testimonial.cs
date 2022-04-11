using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class Testimonial:BaseEntity
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
    }
}
