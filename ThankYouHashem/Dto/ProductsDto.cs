namespace ThankYouHashem.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
        public CategoryDto Category { get; set; }
    }
      public class CreateProductDto
        {
            public string Name { get; set; } = string.Empty;
            public int Price { get; set; }
            public int CategoryId { get; set; }  // שדה חובה בקבלת מוצר חדש
        }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    //public class UserDto
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;
    //    public int Age { get; set; }
    //}

    //public class CreateUserDto
    //{
    //    public string Name { get; set; } = string.Empty;
    //    public int Age { get; set; }
    //}

    //public class OrderProductDto
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;
    //}

    //public class OrderDto
    //{
    //    public int Id { get; set; }
    //    public DateTime OrderDate { get; set; }

    //    // רשימת מוצרים בהזמנה
    //    public List<OrderProductDto> Products { get; set; } = new();
    //}

    //public class CreateOrderDto
    //{
    //    public int UserId { get; set; }

    //    // רק IDs של מוצרים
    //    public List<int> ProductIds { get; set; } = new();
    //}
}



