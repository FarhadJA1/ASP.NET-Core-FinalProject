using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class NoticePanel:BaseEntity
    {
        public string Date { get; set; }
        public string Notice { get; set; }
        public string Size { get; set; }
    }
}
