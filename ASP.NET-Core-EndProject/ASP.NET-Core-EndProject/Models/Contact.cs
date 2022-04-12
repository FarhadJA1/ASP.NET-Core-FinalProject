using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class Contact:BaseEntity
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
    }
}
