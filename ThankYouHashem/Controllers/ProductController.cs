using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;
using ThankYouHashem.Services;

namespace ThankYouHashem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        //dtos

       //קבלת כל המוצרים
        [HttpGet("getAllProducts")]
        public IActionResult GetProductsDto()
        {
            return Ok(_productService.GetOrdersDto());
        }

       
        //הוספת מוצר 1
        [HttpPost("addOneProduct")]
        public IActionResult Create([FromBody] CreateProductDto dto)
        {
            var result = _productService.CreateProduct(dto);
            return Ok(result);
        }

        //הוספת מוצרים
        [HttpPost]
        [Route("AddManyProducts")]
        public IActionResult CreateMany([FromBody] List<CreateProductDto> dtos)
        {
            var result = _productService.CreateMultiple(dtos);
            return Ok(result);
        }


        //get actice products qty procdure
        [HttpGet("activeProductsQty")]
        public IActionResult GetActiveProductsCount()
        {
            int count = _productService.GetActiveProductsCount();
            return Ok(new { activeProducts = count });
        }

        //create product procdure
        [HttpPost]
        [Route("CreateProductByProc")]
        public IActionResult CreateProductByProc([FromBody] ProductDto dto)
        {
            int id = _productService.CreateProductByProc(dto);
            return Ok(new { NewProductId = id });
        }

        [HttpGet("withMap")]
        public IActionResult GetProductsWithMap()
        {
            return Ok(_productService.GetProductsWithMap());
        }


        //בלי דיטיאו
        // קטגוריות ומוצרים שלהם
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(_productService.GetProductWithCategories());
        }

        // מוצרים ממוינים לפי שם
        [HttpGet]
        [Route("GetSortedProducts")]
        public IActionResult GetSortedProducts()
        {
            return Ok(_productService.GetProductsSort());
        }

        // כל ההזמנות והמוצרים שלהם
        [HttpGet("orders")]
        public IActionResult GetFullOrders()
        {
            return Ok(_productService.getFullOrders());
        }
        
        // מוצרים לפי קטגוריה
        [HttpGet("byCategory/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            return Ok(_productService.GetProductsByCategory(categoryId));
        }
    }
}