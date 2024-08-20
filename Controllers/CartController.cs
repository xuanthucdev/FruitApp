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
        [HttpPost]
        public IActionResult AddtoCart([FromBody] AddToCartRequest request)
        {
            var product = productService.findById(request.ProductId);
            if (product == null)
            {
                return Json(new { success = false });
            }
            else
            {
                // Gán số lượng mặc định là 1 nếu không có giá trị
                int quantity = request.Quantity > 0 ? request.Quantity : 1;

                var cartItem = new CartItem
                {
                    ProductID = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    Image = product.Image,
                };
                cartService.AddtoCart(cartItem);
                return Json(new { success = true });
            }
        }

        public class AddToCartRequest
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; } // Có thể nhận giá trị 0 hoặc giá trị hợp lệ
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] int productId)
        {
            Console.WriteLine("Received Product ID: " + productId);
            cartService.RemoveFromCart(productId);
            return Json(new { success = true });
        }




        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        {
            var cart = cartService.GetCartItems();
            var item = cart.FirstOrDefault(i => i.ProductID == request.ProductId);

            if (item != null)
            {
                if (request.Action == "increase")
                {
                    item.Quantity += 1;
                }
                else if (request.Action == "decrease")
                {
                    item.Quantity -= 1;
                    if (item.Quantity <= 0)
                    {
                        cart.Remove(item);
                    }
                }

                cartService.SaveCart(cart);
            }

            return Json(new { success = true });
        }


        public class UpdateQuantityRequest
        {
            public int ProductId { get; set; }
            public string Action { get; set; }
        }



    }
}
