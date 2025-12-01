using System;
using System.Text.Json.Serialization;
namespace ThankYouHashem.Models
{
    public class User
    {

        public int Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();
        public UserProfile Profile { get; set; }
    }
}

