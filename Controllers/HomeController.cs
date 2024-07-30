using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       

    }
}
