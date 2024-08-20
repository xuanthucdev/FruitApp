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
        [HttpGet] 
        public IActionResult AddProduct()
        {
            ViewBag.Categories = categoryService.findAll();
            return View();
        }





        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {

            ViewBag.categories = new SelectList(categoryService.findAll(), "Id", "Name", model.CategoryID);





            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryID = model.CategoryID, 
                    Stock = model.Stock,
                    Image = model.Image

                };
                await productService.AddProduct(product);
                return RedirectToAction("Product");

            }
            else
            {
                
                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

               
                ViewBag.Categories = categoryService.findAll();
                return View(model);
            }


        }

        
        public IActionResult Product()
        {
            ViewBag.categories = categoryService.findAll();
            ViewBag.products = productService.findAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await productService.DeleteProduct(id);
                return RedirectToAction("Product");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra khi xóa sản phẩm.";
                return RedirectToAction("Product");
            }
        }

       
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(await categoryService.FindAllAsync(), "Id", "Name", product.CategoryID);
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProductAsync(product);
                return RedirectToAction("Index");
            }

            
            ViewBag.Categories = new SelectList(await categoryService.FindAllAsync(), "Id", "Name", product.CategoryID);
            return View("EditProduct", product);
        }
        public async Task<IActionResult> AddCategory()

        {
            ViewBag.categories = categoryService.findAll();
            return View();
        }




    }
}
