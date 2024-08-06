using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ProjectDotNet.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index()
		{
            return View(); 
        }
		
    }
}
