using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectDotNet.Models;
using ProjectDotNet.Services;

namespace ProjectDotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ProductService productService;
        private  CategoryService categoryService;
        
        public ProductController (ProductService _productService, CategoryService _categoryService)
        {
            productService = _productService;
            categoryService = _categoryService;
           
        }
       
        public IActionResult Index()
        {
            



            return View();
        }
        public IActionResult Account()
        {
            return View();
        }


        public IActionResult AddProduct1()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            
            ViewBag.categories = new SelectList(categoryService.findAll(), "Id", "Name");
           
           
            if (ModelState.IsValid)
            {
                
                try
                {
                    await productService.AddProduct(product);  

                    
                    TempData["success"] = "Product has been added successfully!";

                  
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
               
                    TempData["error"] = "An error occurred while adding the product.";
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                
                TempData["error"] = "Please correct the errors and try again.";
            }

        
            return View();
        }

        public IActionResult EditProduct()
        {
            return View();
        }
        public IActionResult Product()
        {
            ViewBag.categories = categoryService.findAll();
            ViewBag.products = productService.findAll();
            return View();
        }
        
        
        




    }
}
