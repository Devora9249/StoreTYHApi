using Microsoft.EntityFrameworkCore;
using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;

namespace ThankYouHashem.Repository
{
    public class OrderRepository
    {
        private readonly StoreContext _context;

        public OrderRepository(StoreContext context)
        {
            _context = context;
        }

        public List<OrderDto> GetOrdersDto()
        {
            return _context.Orders
                .Include(p => p.Products)
                .Include(u => u.User)
                .Select(p => new OrderDto
                {
                    Id = p.Id,
                    OrderDate = p.OrderDate,
                    userName = p.User.name,
                    //Products = p.Products.Select(prod => new ProductInOrderDto
                    //{
                    //    ProductId = prod.Id,
                    //    Name = prod.name,
                    //    Price = prod.price
                    //}).ToList()
                })
                .ToList();
        }

        public Order AddOrder(addOrderDto dto)
        {
            var products = _context.Products
                .Where(p => dto.ProductsIds.Contains(p.Id))
                .ToList();

            var newOrder = new Order
            {
                OrderDate = dto.orderDate,
                UserId = dto.userId,
                Products = products
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            return newOrder;
        }
    }
}
