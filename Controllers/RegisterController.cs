using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNet.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
