using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;

namespace ThankYouHashem.Services
{
    public class NotificationSmsService : INotificationService
    {
        public void send(string message)
        {
            Console.WriteLine("Sending SMS notification: " + message);
        }
    }
}
