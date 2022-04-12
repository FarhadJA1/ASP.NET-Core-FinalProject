using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public class Blog:BaseEntity
    {
        public string Image { get; set; }
        public string From { get; set; }
        public string Date { get; set; }
        public string CommentCount { get; set; }
        public string Title { get; set; }
        public string PostImage { get; set; }
        public string Description { get; set; }

    }
}
