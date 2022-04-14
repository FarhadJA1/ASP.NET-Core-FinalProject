using ASP.NET_Core_EndProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels.Admin
{
    public class TeacherCreateVM
    {
        public int Id { get; set; }
        [Required]
        public Teacher Teacher { get; set; }
        [Required]
        public List<int> Percent { get; set; }
        [Required]
        public TeacherDetail TeacherDetail { get; set; }
        [Required]
        public TeacherContact TeacherContact { get; set; }
        [Required]
        public List<Skills> Skills { get; set; }
        [Required]
        public IFormFile Photo { get; set; }

    }
}
