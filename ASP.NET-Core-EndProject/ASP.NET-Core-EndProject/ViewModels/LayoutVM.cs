using ASP.NET_Core_EndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels
{
    public class LayoutVM
    {
        public Setting Setting { get; set; }
        public List<SocNetwork> SocialNetwork { get; set; }
        public Subscribe Subscribe { get; set; }
    }
}
