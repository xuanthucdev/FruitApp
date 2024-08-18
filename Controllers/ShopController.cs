using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Models;
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
        public IActionResult ProductsByCategory(int categoryId)
        {
            ViewBag.categories = categoryService.findAll();
            var products = productService.findByCategoryIdd(categoryId);
            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryName = "Category Name"; 
            return View(products);
        }
        public IActionResult SearchProducts(string query)
        {
            ViewBag.categories = categoryService.findAll();
            var products = productService.SearchProducts(query);
           

            return View("SearchProducts",products); 
        }


    }
}
