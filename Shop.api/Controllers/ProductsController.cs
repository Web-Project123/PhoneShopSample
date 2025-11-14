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
                new Product { Id = 1, Name = "Laptop", Price = 35000000, Stock = 5 },
                new Product { Id = 2, Name = "Mouse", Price = 150000, Stock = 20 },
                new Product { Id = 3, Name = "Keyboard", Price = 450000, Stock = 10 }
            };

            return Ok(products);
        }
    }
}