using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Models;
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
        
        public async Task<IActionResult> Index(int id)
        {
           
            var categories = await categoryService.FindAllAsync();

            var categoriesWithProductCount = new List<CategoryProductCount>();

            foreach (var category in categories)
            {
                var productCount = await productService.GetProductCountByCategoryAsync(category.Id);
                categoriesWithProductCount.Add(new CategoryProductCount
                {
                    Category = category,
                    ProductCount = productCount
                });
            }

            ViewBag.Categories = categoriesWithProductCount;



            
            var product =  productService.findById(id);
            if (product == null)
            {
                return NotFound();
            }
            

            return View(product);




        }
    }
}
