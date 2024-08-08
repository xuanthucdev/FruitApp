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
            return db.Products
           .Include(p => p.category)
           .Join(db.DescriptionDetails,
                 p => p.DescriptionID,
                 d => d.Id,
                 (p, d) => new
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Price = p.Price,
                     Image = p.Image,
                     CategoryName = p.category.Name,
                     Description = d.Description,
                     Weight = d.weight,
                     Country = d.country,
                     MaxWeight = d.maxWeight,
                     Quality = d.quality,
                     Status = d.status

                 })
           .ToList();

        }

        public Product findById(int id)
        {
            return db.Products.Include(p => p.category).FirstOrDefault(p => p.Id == id);
        }
    }
}
