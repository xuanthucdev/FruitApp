using ProjectDotNet.Models;

namespace ProjectDotNet.Services
{
    public interface CartService
    {
        public void AddtoCart(CartItem item);
        public List<CartItem> GetCartItems();
        public void SaveCart(List<CartItem> cartItems);

    }
}
