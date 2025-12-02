

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ThankYouHashem.Models
{
    public interface INotificationService
    {
        public void send(string message);

    }
}
