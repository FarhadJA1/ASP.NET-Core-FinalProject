using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class Setting:BaseEntity
    {
        public string HeaderLogo { get; set; }
        public string HeaderPhone { get; set; }
        public string FooterLogo { get; set; }
        public string FooterDesc { get; set; }
        public string Address { get; set; }
        public string FirstPhone { get; set; }
        public string SecondPhone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
    }
}
