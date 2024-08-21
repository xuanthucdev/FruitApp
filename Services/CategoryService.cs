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
        public async Task UpdateCategoryAsync(Category cate)
        {
            var existingCate = await db.Categories.FindAsync(cate.Id);
            if (existingCate != null)
            {
                // Update the properties of the existing category
                existingCate.Name = cate.Name;
                existingCate.Description = cate.Description;

                // Update the existing entity
                db.Categories.Update(existingCate);

                // Save changes to the database
                await db.SaveChangesAsync();
            }
            else
            {
                // Optionally handle the case where the category was not found
                throw new Exception("Category not found");
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }




    }
}
