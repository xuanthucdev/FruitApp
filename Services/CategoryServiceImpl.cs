using ProjectDotNet.Database;
using ProjectDotNet.Models;
using System.Data.Entity;

namespace ProjectDotNet.Services
{
    public class CategoryServiceImpl : CategoryService
    {
        private MyDBContext db;
        public CategoryServiceImpl(MyDBContext _db)
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

       

       
    }
}
