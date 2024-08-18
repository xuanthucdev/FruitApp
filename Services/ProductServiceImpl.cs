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
                CategoryName = p.category.Name, 
                CategoryDes = p.category.Description
            }).ToList();
        }

       

      

        public Product findById(int id)
        {
            return db.Products.Include(p => p.category).FirstOrDefault(p => p.Id == id);
        }
        public Product findByCategoryId(int id)
        {
            return db.Products.Include(p => p.category).FirstOrDefault(p => p.category.Id == id);
        }
        public List<Product> getAll()
        {
            return db.Products.Include(p => p.category).Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
               
                Price = p.Price
            }).ToList();

        }

        public dynamic getListKeyword()
        {
            return db.Products.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Description = p.Description,
                Price = p.Price,
                Keywords = p.Productkeywords.Select(p => new
                {
                    Name = p.Keyword.Name
                }).ToList()
            }).ToList();
        }

        public dynamic searchByName(string name)
        {
            return db.Products.Where(p => p.Name.Contains(name)).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Description = p.Description,
                Price = p.Price,
                Keywords = p.Productkeywords.Select(p => new
                {
                    Name = p.Keyword.Name
                }).ToList()
            }).ToList();
        }

        public List<ProductWithCategory> findByCategoryIdd(int categoryId)
        {
            return db.Products
            .Where(p => p.CategoryID == categoryId)
            .Select(p => new ProductWithCategory
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image,
              CategoryName = p.category.Name,
                CategoryDes = p.category.Description
            }).ToList();
        }

        public dynamic SearchProducts(string query)
        {
            return db.Products
      .Include(p => p.category)  
      .Where(p => p.Name.Contains(query))
      .Select(p => new
      {
          Id = p.Id,
          Name = p.Name,
          Price = p.Price,
          Image = p.Image,
          CategoryName = p.category.Name,  
          CategoryDes = p.category.Description  
      }).ToList();
        }
    }
}
