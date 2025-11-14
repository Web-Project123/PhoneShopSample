using Microsoft.AspNetCore.Mvc;
using PhoneShopSample.Models;



namespace Shop.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Iphone", Price = 300, Stock = 5 },
                new Product { Id = 2, Name = "Samsong",  Price = 200,   Stock = 20 },
                new Product { Id = 3, Name = "Xiaomi", Price = 100, Stock = 50 },
                new Product { Id = 4, Name = "Huawei", Price = 50, Stock = 2 }
            };

            return Ok(products);
        }
    }
}