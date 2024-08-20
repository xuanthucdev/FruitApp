using Newtonsoft.Json;
using ProjectDotNet.Models;

namespace ProjectDotNet.Services
{
    public class CartService 
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private const string CartSessionKey = "Cart";
        public CartService(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;

        }
        public void AddtoCart(CartItem item)
        {
           var cart = GetCartItems();
            var existingItem = cart.FirstOrDefault(i => i.ProductID == item.ProductID);
            if (existingItem == null) {
                cart.Add(item);
            }
            else
            {
                existingItem.Quantity += item.Quantity;
            }
            SaveCart(cart);
        }

        public List<CartItem> GetCartItems()
        {
            var session = httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            return JsonConvert.DeserializeObject<List<CartItem>>(cartJson);

        }

        public void SaveCart(List<CartItem> cartItems)
        {
            var session = httpContextAccessor.HttpContext.Session; 
            var cartJson = JsonConvert.SerializeObject(cartItems);
            session.SetString(CartSessionKey, cartJson);
        }
        public void RemoveFromCart(int productId)
        {
            var cart = GetCartItems();

            var item = cart.FirstOrDefault(i => i.ProductID == productId);

            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
                Console.WriteLine("Item removed: " + productId);
            }
            else
            {
                Console.WriteLine("Item not found: " + productId);
            }
        }
    }
}
