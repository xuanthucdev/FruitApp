using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Services;

namespace ProjectDotNet.Controllers
{
    public class ShopController : Controller
    {
       private ProductService productService;
      private CategoryService categoryService;
        public ShopController(ProductService _productService, CategoryService _categoryService)
        {
            productService = _productService;
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            ViewBag.products = productService.findAll();
            ViewBag.categories = categoryService.findAll();
            return View();
        }
    }
}
