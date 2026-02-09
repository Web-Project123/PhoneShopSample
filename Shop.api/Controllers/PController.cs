




using Microsoft.AspNetCore.Mvc;
using PhoneShop.Application.DTOs;

namespace Shop.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            return Ok("محصول ثبت شد");
        }
    }
}