using ProjectDotNet.Database;
using ProjectDotNet.Models;
using System.Data.Entity;

namespace ProjectDotNet.Services
{
    public class ProductServiceImpl : ProductService




    {
        private MyDBContext db;
        public ProductServiceImpl(MyDBContext _db)
        {
            db = _db;
        }

        public dynamic findAll()
        {
            return db.Products.Include(p => p.category).Select(p => new {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
                CategoryName = p.category.Name // Bao gồm tên danh mục
            }).ToList();
        }

        public Product findById(int id)
        {
            return db.Products.Include(p => p.category).FirstOrDefault(p => p.Id == id);
        }
    }
}
