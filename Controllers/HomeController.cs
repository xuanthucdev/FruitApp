using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using ProjectDotNet.Database;
using ProjectDotNet.Models;
using ProjectDotNet.Services;
using System.Diagnostics;

namespace ProjectDotNet.Controllers
{
    public class HomeController : Controller
    {
        
       
        private CategoryService categoryService;
        private ProductService productService;
        private readonly ILogger<HomeController> logger;
        

        public HomeController(ILogger<HomeController> _logger, CategoryService _categoryService, ProductService _productService )
        {
            logger = _logger;
           categoryService = _categoryService;
            productService = _productService;
           
        }

        public IActionResult Index()

		{

            var categories = categoryService.findAll();
            var products = productService.findAll();
            ViewBag.categories = categories;
            return View(products); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
