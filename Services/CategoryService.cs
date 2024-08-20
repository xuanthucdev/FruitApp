using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Database;
using ProjectDotNet.Models;


namespace ProjectDotNet.Services
{
    public class CategoryService 
    {
        private MyDBContext db;
        public CategoryService(MyDBContext _db)
        {
            db = _db;
        }



        public dynamic findAll()
            {
            return db.Categories
     .Include(c => c.Products)  
     .Select(c => new {
         c.Id,
         c.Name,
         c.Description,
         Products = c.Products.Select(p => new {
             p.Id,
             p.Name,
             p.Price,
             p.Image
         }).ToList()  
     })
     .ToList();  
        }
        public async Task<IEnumerable<Category>> FindAllAsync()
        {
            return await db.Categories.ToListAsync();
        }



    }
}
