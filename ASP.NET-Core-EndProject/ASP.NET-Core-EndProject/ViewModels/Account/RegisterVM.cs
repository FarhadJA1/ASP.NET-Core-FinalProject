using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewModels.Account
{
    public class RegisterVM
    {
        [Required,MaxLength(50),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,MaxLength(50)]
        public string Username { get; set; }
        [Required,MaxLength(30), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,MaxLength(30), DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
