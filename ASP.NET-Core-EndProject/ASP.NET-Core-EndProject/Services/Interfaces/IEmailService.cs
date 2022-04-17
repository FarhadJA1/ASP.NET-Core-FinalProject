using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailAddressTo, string userName, string html, string content);
    }
}
