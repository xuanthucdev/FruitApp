using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Database;
using ProjectDotNet.Models;







namespace ProjectDotNet.Services
{
    public class ProductService




    {
        private MyDBContext db;
        public ProductService(MyDBContext _db)
        {
            db = _db;
        }

        public dynamic findAll()
        {
            return db.Products.OrderBy(p=> p.Id).Include(p => p.category).Select(p => new {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,

                CategoryName = p.category.Name, 
                CategoryDes = p.category.Description,
                Stock = p.Stock
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
               Stock = p.Stock,
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
                Stock = p.Stock,
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
                Stock = p.Stock,
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
                Stock = p.Stock,
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
          Stock = p.Stock,
          CategoryName = p.category.Name,  
          CategoryDes = p.category.Description  
      }).ToList();
        }
        public async Task AddProduct(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await db.Products
                                   .Include(p => p.category)
                                   .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await db.Products.FindAsync(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.Stock = product.Stock;
                existingProduct.Image = product.Image;

                db.Products.Update(existingProduct);
                await db.SaveChangesAsync();
            }
        }
        public async Task<int> GetProductCountByCategoryAsync(int categoryId)
        {
            return await db.Products.CountAsync(p => p.CategoryID == categoryId);
        }
        public async Task<List<Product>> FindAllAsync()
        {
            
            return await db.Products
                .Include(p => p.category) 
                .ToListAsync();
        }
    }

}
