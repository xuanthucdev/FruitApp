using ProjectDotNet.Database;

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
                return db.Categories.Select(c => 
                new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Des = c.Description
                }
                ).ToList();
            }
        
    }
}
