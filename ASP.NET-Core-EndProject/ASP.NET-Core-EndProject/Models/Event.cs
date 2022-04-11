using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class Event:BaseEntity
    {
        public string Image { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
    }
}
