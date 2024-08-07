using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNet.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
