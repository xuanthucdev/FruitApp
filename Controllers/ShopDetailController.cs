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
        
        public IActionResult Index(int id)
        {
            ViewBag.categories = categoryService.findAll();
            var product =  productService.findById(id);
            if (product == null)
            {
                return NotFound();
            }
            

            return View(product);
        }
    }
}
