using System.Text.Json.Serialization;

namespace ThankYouHashem.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
      

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();

        
    }
}
