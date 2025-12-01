using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;
using ThankYouHashem.Repository;

namespace ThankYouHashem.Services
{
    public class OrderService
    {
        private readonly OrderRepository _repository = new();

        //dto
        public List<OrderDto> GetOrdersDto()

        {
            return _repository.GetOrdersDto();
        }

        public Order addOrder(addOrderDto order) { 
            return _repository.AddOrder(order);
        }
     
    }
}
