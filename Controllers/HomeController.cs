using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using ProjectDotNet.Database;
using ProjectDotNet.Models;
using ProjectDotNet.Services;
using System.Diagnostics;
using X.PagedList.Extensions;

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

        public async Task<IActionResult> Index(int categoryId)

		{
            int cateIDOfGiamGia = 7;
            int cateIDOfBanChay = 8;
            var categories = await categoryService.FindAllAsync();
            var products = await productService.FindAllAsync();
            ViewBag.categories = categories;
           ViewBag.products = products;

            var productsOfgGiamGia = productService.findByCategoryIdd(7);
            var productsOfgBanChay = productService.findByCategoryIdd(8);
            ViewBag.giamgia = productsOfgGiamGia;

            ViewBag.banchay =  productsOfgBanChay;


            return View(products); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
