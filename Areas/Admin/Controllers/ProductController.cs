using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectDotNet.Models;
using ProjectDotNet.Services;

namespace ProjectDotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;
        private readonly OrderService orderService;
        public ProductController (ProductService _productService, CategoryService _categoryService, OrderService _orderService)
        {
            productService = _productService;
            categoryService = _categoryService;
            orderService = _orderService;
           
        }

        public async Task<IActionResult> Index()
        {
            var list = await orderService.GetAllOrderAsync();
            return View(list);
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
            catch (Exception                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ex)
            {
                TempData["Error"] = "Có lỗi xảy ra khi xóa sản phẩm.";
                return RedirectToAction("Product");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await productService.DeleteCategory(id);
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
        public async Task<IActionResult> EditProductSave(Product product)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProductAsync(product);
                return RedirectToAction("Product");
            }


            ViewBag.Categories = new SelectList(await categoryService.FindAllAsync(), "Id", "Name", product.CategoryID);
            return View("EditProduct", product);
        }
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                // Handle the case where the category is not found (e.g., return a NotFound view or redirect)
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        public async Task<IActionResult> EditCategorySave(Category cate)
        {
            if (ModelState.IsValid)
            {
                await categoryService.UpdateCategoryAsync(cate);
                return RedirectToAction("Product");
            }


            return View("EditCategory", cate);
        }




        public async Task<IActionResult> AddCategory()

        {
            ViewBag.categories = categoryService.findAll();
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> AddCategory(Category cate)
        {

            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = cate.Name,
                    Description = cate.Description,
                  

                };
                await productService.AddCategory(category);
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


                
                return View(cate);
            }
        }
       



    }
}
