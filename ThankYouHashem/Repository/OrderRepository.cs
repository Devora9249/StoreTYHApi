using AutoMapper;
using BooksApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;

namespace ThankYouHashem.Repository
{
    public class OrderRepository

    {
        StoreContext context = LibraryContextFactory.CreateContext();


        public List<OrderDto> GetOrdersDto()
        {
            return context.Orders
                .Include(p => p.Products)
                .Include(u=>u.User)
                .Select(p => new OrderDto
                {
                    Id = p.Id,
                    OrderDate = p.OrderDate,
                    userName = p.User.name,
                    Products = p.Products.Select(prod => new ProductInOrderDto
                    {
                        ProductId = prod.Id,
                        Name = prod.name,
                        Price = prod.price,
                    }).ToList()
                })
                .ToList();
        }


        public Order AddOrder(addOrderDto dto)
        {
            var products = context.Products
                .Where(p => dto.ProductsIds.Contains(p.Id))
                .ToList();

            var newOrder = new Order
            {
                OrderDate = dto.orderDate,
                UserId = dto.userId,
                Products = products
            };

            context.Orders.Add(newOrder);
            context.SaveChanges();

            return newOrder;
        }

    }
}
