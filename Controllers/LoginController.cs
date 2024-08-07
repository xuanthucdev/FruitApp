using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
