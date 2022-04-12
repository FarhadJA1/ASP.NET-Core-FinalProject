using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class Advert:BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
    }
}
