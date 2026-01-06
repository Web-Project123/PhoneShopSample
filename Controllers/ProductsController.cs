using Microsoft.AspNetCore.Mvc;
using Web_Project.Application.Services;
using Web_Project.Domain.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Product> Get() => _service.GetAllProducts();

        [HttpGet("{id}")]
        public Product? Get(int id) => _service.GetProduct(id);

        [HttpPost]
        public void Post([FromBody] Product product) => _service.AddProduct(product);
    }
}
