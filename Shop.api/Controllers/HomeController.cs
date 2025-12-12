using Microsoft.AspNetCore.Mvc;

namespace Shop.api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
