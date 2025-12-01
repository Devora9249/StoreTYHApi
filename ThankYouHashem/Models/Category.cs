

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ThankYouHashem.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name   { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
