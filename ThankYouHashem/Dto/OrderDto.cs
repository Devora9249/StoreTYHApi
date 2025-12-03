using System.Net.Http.Headers;

namespace ThankYouHashem.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string userName { get; set; }
        //public List<ProductInOrderDto> Products { get; set; } = new();

    }

    public class ProductInOrderDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class addOrderDto
    {
        public DateTime orderDate { get; set; }

        public int userId { get; set; }
        public List<int> ProductsIds { get; set; } = new();

    }


}



