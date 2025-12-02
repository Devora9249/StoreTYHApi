using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;
using ThankYouHashem.Services;

namespace ThankYouHashem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        private readonly INotificationService _notify;

        public OrderController(INotificationService notify)
        {
            _orderService = new OrderService();
            _notify = notify;
        }


        //dtos

        //קבלת כל המוצרים
        [HttpGet("GetAllProductsDto")]
        public IActionResult GetOredrsDto()
        {
            return Ok(_orderService.GetOrdersDto());
        }

       
        //הוספת הזמנה 1
        [HttpPost("addOrder")]
        public IActionResult Create([FromBody] addOrderDto order)
        {
            var result = _orderService.addOrder(order);
            _notify.send("New order has been created with ID: " + result.Id);
            
            return Ok(result);
        }

    }
}