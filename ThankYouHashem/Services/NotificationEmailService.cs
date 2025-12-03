using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;

namespace ThankYouHashem.Services
{
    public class NotificationEmailService : INotificationService
    {
        //public void send(string message)
        //{
        //    Console.WriteLine("Sending Email notification: " + message);
        //}

        private readonly IConfiguration _config;

        public NotificationEmailService(IConfiguration config)
        {
            _config = config;
        }

        public void send(string message)
        {
            var settings = _config.GetSection("EmailSettings");

            var smtp = new SmtpClient(settings["Host"])
            {
                Port = int.Parse(settings["Port"]),
                EnableSsl = bool.Parse(settings["EnableSSL"]),
                Credentials = new NetworkCredential(
                    settings["Username"],
                    settings["Password"]
                )
            };

            var mail = new MailMessage
            {
                From = new MailAddress(settings["Username"], "My App"),
                Subject = "התראה מהמערכת",
                Body = message
            };

            mail.To.Add("devora.video@gmail.com"); // למי לשלוח
            mail.To.Add("porat4241@gmail.com"); // למי לשלוח
            smtp.Send(mail);
        }
    }
}
