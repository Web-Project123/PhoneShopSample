using Microsoft.AspNetCore.Mvc;
using PhoneShop.Application.Services;
using System;
using System.Threading.Tasks;

namespace Shop.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            await _service.AddAsync(dto.Name, dto.Price, dto.Stock);
            return CreatedAtAction(nameof(GetById), new { id = /* can't access id easily — use query */ Guid.NewGuid() }, null);
        }
    }

    public record CreateProductDto(string Name, decimal Price, int Stock);
}
