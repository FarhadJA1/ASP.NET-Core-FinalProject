using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
