using ASP.NET_Core_EndProject.Services.Interfaces;
using ASP.NET_Core_EndProject.Utilities.Helpers;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string emailAddressTo,string userName,string html,string content)
        {
            var emailModel = _configuration.GetSection("EmailConfig").Get<EmailRequest>();
            var apiKey = emailModel.SecretKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailModel.SenderEmail, emailModel.SenderName);
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(emailAddressTo, userName);
            var plainTextContent = content;
            var htmlContent = html;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
       
    }
}
