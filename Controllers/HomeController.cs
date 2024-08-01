using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ProjectDotNet.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index()
		{
            return View(); // Đặt đường dẫn tới view
        }
		public IActionResult Shop()
		{
			return View();
		}

		public IActionResult ShopDetail()
		{
			return View();
		}

		public IActionResult Cart()
		{
			return View();
		}

		public IActionResult Checkout()
		{
			return View();
		}

		public IActionResult Testimonial()
		{
			return View();
		}

		public IActionResult Page404()
		{
			return View();
		}
        public IActionResult Login()
        {
            return View();
        }

    }
}
