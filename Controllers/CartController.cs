using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNet.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
