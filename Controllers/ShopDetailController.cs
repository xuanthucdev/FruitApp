using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Services;

namespace ProjectDotNet.Controllers
{
    public class ShopDetailController : Controller
    {
        private CategoryService categoryService;
        private ProductService productService;
        public ShopDetailController (CategoryService _categoryService, ProductService _productService)
        {
            categoryService = _categoryService;
            productService = _productService;

        }
        
        public IActionResult Index()
        {
            ViewBag.products = productService.findAll();
            ViewBag.categories = categoryService.findAll();

            return View();
        }
    }
}
