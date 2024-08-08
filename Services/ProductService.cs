using ProjectDotNet.Models;

namespace ProjectDotNet.Services
{
    public interface ProductService
    {
        public dynamic findAll();
        public Product findById(int id);
    }
}
