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

        public OrderController()
        {
            _orderService = new OrderService();
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
            return Ok(result);
        }

    }
}