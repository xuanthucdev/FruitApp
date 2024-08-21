using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Models;
using ProjectDotNet.Services;
using X.PagedList.Extensions;

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

        public async Task<IActionResult> Index(string sortOrder, int page = 1, int pageSize = 9, int maxPrice = 1000000)
        {
            // Lấy tất cả sản phẩm
            var products = await productService.FindAllAsync();

            // Lọc sản phẩm theo giá
            if (maxPrice > 0)
            {
                products = products.Where(p => p.Price <= maxPrice).ToList();
            }

            // Sắp xếp sản phẩm
            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case "name_asc":
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name).ToList();
                    break;
                default:
                    break;
            }

            // Phân trang
            var pagedProducts = products.ToPagedList(page, pageSize);

            ViewBag.products = pagedProducts;

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
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MaxPrice = maxPrice;

            return View(pagedProducts);
        }



        public async Task<IActionResult> ProductsByCategory(int categoryId, string sortOrder, int page = 1, int pageSize = 9)
        {
            var products = productService.findByCategoryIdd(categoryId);
            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case "name_asc":
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name).ToList();
                    break;
                default:

                    break;
            }


            var pagedProducts = products.ToPagedList(page, pageSize);

            ViewBag.products = pagedProducts;

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
           
            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryName = "Category Name"; 
            return View(pagedProducts);
        }
        public async Task<IActionResult> SearchProducts(string query, string sortOrder)
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
            var products = productService.SearchProducts(query);









            return View("SearchProducts",products); 
        }


    }
}
