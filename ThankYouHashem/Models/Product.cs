
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ThankYouHashem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        public string? description { get; set; }
        public int price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();

        [JsonIgnore]

        public List<Order> Orders { get; set; } = new List<Order>();

        public bool IsDeleted { get; set; }



    }
}

