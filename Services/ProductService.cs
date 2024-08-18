using ProjectDotNet.Models;

namespace ProjectDotNet.Services
{
    public interface ProductService
    {
        public dynamic findAll();
        public Product findById(int id);
        public Product findByCategoryId(int id);
        

        public dynamic searchByName(string name);
        public dynamic getListKeyword();
        public List<Product> getAll();
        public List<ProductWithCategory> findByCategoryIdd(int categoryId);
        public dynamic SearchProducts(string query);
    }
}
