using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using ProjectDotNet.Models;
using ProjectDotNet.Services;
using System.Diagnostics;

namespace ProjectDotNet.Controllers
{
    public class HomeController : Controller
    {
        
       
        private CategoryService categoryService;
        private ProductService productService;

        public HomeController(CategoryService _categoryService, ProductService _productService )
        {
           categoryService = _categoryService;
            productService = _productService;
           
        }

        public IActionResult Index()

		{
            ViewBag.product = productService.findAll();
            ViewBag.categories = categoryService.findAll();
            return View(); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
