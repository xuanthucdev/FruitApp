using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Models;
using ProjectDotNet.Services;

namespace ProjectDotNet.Controllers
{
    public class CartController : Controller
    {
        private CartService cartService;
        private ProductService productService;
        public CartController(CartService _cartService, ProductService _productService) { 
            cartService = _cartService;
            productService = _productService;
        }

        public IActionResult Index()
        {
            var cart = cartService.GetCartItems();
            return View(cart);
            
        }
        public IActionResult AddtoCart(int id) {
            var product = productService.findById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductID = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1,
                    Image = product.Image,
                };
                cartService.AddtoCart(cartItem);
                return RedirectToAction("Index");
            }
        }


    }
}
